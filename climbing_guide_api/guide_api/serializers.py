from rest_framework import serializers
from parler_rest.serializers import TranslatableModelSerializer, TranslatedFieldsField
from .models import Region, Area, Sector, Route, RouteType
from django.contrib.auth.models import User
from django.core.files.uploadedfile import SimpleUploadedFile

import base64
# import pdb # pdb.set_trace()


class DisplayUserSerializer(serializers.ModelSerializer):

    class Meta:
        model = User
        fields = ('id', 'username')


class DynamicFieldsModelSerializer(serializers.ModelSerializer):
    """
    A ModelSerializer that takes an additional `fields` argument that
    controls which fields should be displayed.
    Or light swith, which uses predefined subset of fields
    """
    light_fields = ()

    def __init__(self, *args, **kwargs):
        # Instantiate the superclass normally
        super(DynamicFieldsModelSerializer, self).__init__(*args, **kwargs)

        fields = self.context['request'].query_params.get('fields')
        light = self.context['request'].query_params.get('light')
        if fields:
            fields = fields.split(',')
            # Drop any fields that are not specified in the `fields` argument.
            allowed = set(fields)
            existing = set(self.fields.keys())
            for field_name in existing - allowed:
                self.fields.pop(field_name)
        elif light:
            allowed = set(self.light_fields)
            existing = set(self.fields.keys())
            for field_name in existing - allowed:
                self.fields.pop(field_name)


class RegionSerializer(DynamicFieldsModelSerializer, TranslatableModelSerializer):
    id = serializers.IntegerField(read_only=True)
    created_by = DisplayUserSerializer(read_only=True)
    approved_by = DisplayUserSerializer(read_only=True)
    created_on = serializers.DateTimeField(read_only=True)
    approved_on = serializers.DateTimeField(read_only=True)

    name = serializers.CharField(max_length=100, required=True)
    info = serializers.CharField(required=True)
    latitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    longitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    size = serializers.FloatField(required=True)

    light_fields = ('id', 'name', 'info', 'latitude', 'longitude', 'size', 'country_code')

    def create(self, validated_data):
        # TODO: Region admin check
        user = self.context['request'].user
        region = Region.objects.create(created_by = user, **validated_data)

        # Set the user that creates and region as it's admin
        region.admins.add(user)
        region.save()

        return region

    class Meta:
        model = Region
        fields = ('id', 'name', 'info', 'restrictions', 'latitude',
            'longitude', 'size', 'created_on', 'approved_on', 'created_by',
            'approved_by', 'country_code', 'tags')


class AreaSerializer(DynamicFieldsModelSerializer, TranslatableModelSerializer):
    id = serializers.IntegerField(read_only=True)
    created_by = DisplayUserSerializer(read_only=True)
    approved_by = DisplayUserSerializer(read_only=True)
    created_on = serializers.DateTimeField(read_only=True)
    approved_on = serializers.DateTimeField(read_only=True)

    name = serializers.CharField(max_length=100, required=True)
    info = serializers.CharField(required=True)
    latitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    longitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    size = serializers.FloatField(required=True)
    region_id = serializers.IntegerField(required=True)

    light_fields = ('id', 'region_id', 'name', 'info', 'latitude', 'longitude', 'size')

    def validate_region_id(self, value):
        region_id = self.context['view'].kwargs['id']
        region = Region.objects.get(id=region_id)

        if region is None:
            raise serializers.ValidationError("Region not found.")
        # elif not region.active:
        #     raise serializers.ValidationError("Selected region is not available anymore.")
        elif value != region_id:
            raise serializers.ValidationError("Inconsistent data region id in payload does not match the one from the query")

        return value

    def create(self, validated_data):
        # TODO: Area admin check
        request = self.context['request']
        user = request.user
        area = Area.objects.create(created_by=user, **validated_data)

        # Set the user that creates and area as it's admin
        area.admins.add(user)
        area.save()

        return area

    class Meta:
        model = Area
        fields = ('id', 'region_id', 'name', 'info', 'restrictions', 'access', 'descent',
            'latitude', 'longitude', 'size', 'created_on', 'approved_on', 'created_by',
            'approved_by', 'tags')


class SectorSerializer(DynamicFieldsModelSerializer, TranslatableModelSerializer):
    id = serializers.IntegerField(read_only=True)
    created_by = DisplayUserSerializer(read_only=True)
    approved_by = DisplayUserSerializer(read_only=True)
    created_on = serializers.DateTimeField(read_only=True)
    approved_on = serializers.DateTimeField(read_only=True)

    name = serializers.CharField(max_length=100, required=True)
    info = serializers.CharField(required=True)
    latitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    longitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    size = serializers.FloatField(required=True)
    area_id = serializers.IntegerField(required=True)

    light_fields = ('id', 'area_id', 'name', 'info', 'latitude', 'longitude', 'size')

    def validate_area_id(self, value):
        area_id = self.context['view'].kwargs['id']
        area = Area.objects.get(id=area_id)

        if area is None:
            raise serializers.ValidationError("Area not found.")
        # elif not area.active:
        #     raise serializers.ValidationError("Selected area is not available anymore.")
        elif value != area_id:
            raise serializers.ValidationError("Inconsistent data area id in payload does not match the one from the query")

        return value

    def create(self, validated_data):
        request = self.context['request']
        user = request.user
        sector = Sector.objects.create(created_by=user, **validated_data)

        return sector

    class Meta:
        model = Sector
        ref_name = 'Sector'
        fields = ('id', 'area_id', 'name', 'info', 'access', 'descent',
            'latitude', 'longitude', 'size', 'created_on', 'approved_on', 'created_by',
            'approved_by', 'tags')


class RouteSerializer(DynamicFieldsModelSerializer, TranslatableModelSerializer):
    id = serializers.IntegerField(read_only=True)
    created_by = DisplayUserSerializer(read_only=True)
    approved_by = DisplayUserSerializer(read_only=True)
    created_on = serializers.DateTimeField(read_only=True)
    approved_on = serializers.DateTimeField(read_only=True)
    schema_256 = serializers.ImageField(read_only=True)
    schema_2048 = serializers.ImageField(read_only=True)

    name = serializers.CharField(max_length=100, required=True)
    info = serializers.CharField(required=True)
    latitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    longitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    sector_id = serializers.IntegerField(required=True)
    type = serializers.ChoiceField(choices=RouteType.ROUTE_TYPE_CHOICES, required=True)

    schema_base_64 = serializers.CharField(required=False)
    schema_filename = serializers.CharField(required=False)
    schema_content_type = serializers.CharField(required=False)

    light_fields = ('id', 'sector_id', 'name', 'info', 'difficulty', 'rating', 'type',
            'schema_256', 'schema_2048', 'latitude', 'longitude')

    def validate_sector_id(self, value):
        sector_id = self.context['view'].kwargs['id']
        sector = Sector.objects.get(id=sector_id)

        if sector is None:
            raise serializers.ValidationError("Sector not found.")
        # elif not sector.active:
        #     raise serializers.ValidationError("Selected sector is not available anymore.")
        elif value != sector_id:
            raise serializers.ValidationError("Inconsistent data sector id in payload does not match the one from the query")

        return value

    def create(self, validated_data):
        request = self.context['request']
        user = request.user

        if ('schemaBase64' in validated_data and
            'schemaFilename' in validated_data):
            schema_data = validated_data['schema_base_64']
            schema_filename = validated_data['schema_filename']
            schema_content_type = validated_data['schema_content_type']
            validated_data.pop('schema_base_64')
            validated_data.pop('schema_filename')
            validated_data.pop('schema_content_type')

            if (schema_data is not None and
                schema_filename is not None and
                schema_content_type is not None):
                data = base64.b64decode(schema_data)
                validated_data['schema'] = SimpleUploadedFile(schema_filename, data, schema_content_type)

        route = Route.objects.create(created_by=user, **validated_data)

        return route

    class Meta:
        model = Route
        fields = ('id', 'sector_id', 'name', 'info', 'fa', 'difficulty', 'rating', 'length', 'type',
            'schema', 'schema_256', 'schema_2048', 'latitude', 'longitude', 'created_on',
            'approved_on', 'created_by', 'approved_by', 'tags', 'schema_base_64', 'schema_filename',
            'schema_content_type')


class GradeSerializer(serializers.Serializer):
    type = serializers.ChoiceField(choices=RouteType.ROUTE_TYPE_CHOICES, read_only=True)
    value = serializers.IntegerField(read_only=True)
    name = serializers.CharField(read_only=True)


class GradeSystemSerializer(serializers.Serializer):
    id = serializers.IntegerField(read_only=True)
    name = serializers.CharField(read_only=True)


class GradeSystemListSerializer(serializers.Serializer):
    routeType = serializers.IntegerField(read_only=True)
    gradeSystems = GradeSystemSerializer(read_only=True, many=True)