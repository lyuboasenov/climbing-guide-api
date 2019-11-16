from rest_framework import serializers
from parler_rest.serializers import TranslatableModelSerializer, TranslatedFieldsField
from .models import Area, Route, RouteType, Country
from django.contrib.auth.models import User
from django.core.files.uploadedfile import SimpleUploadedFile

import base64
# import pdb # pdb.set_trace()
import pdb


class DisplayUserSerializer(serializers.ModelSerializer):

    class Meta:
        model = User
        fields = ('id', 'username')


class DynamicFieldsModelSerializer(serializers.ModelSerializer):
    """
    A ModelSerializer that takes an additional `fields` argument that
    controls which fields should be displayed.
    """

    def __init__(self, *args, **kwargs):
        # Instantiate the superclass normally
        super(DynamicFieldsModelSerializer, self).__init__(*args, **kwargs)

        fields = self.context['request'].query_params.get('fields')
        if fields:
            fields = fields.split(',')
            # Drop any fields that are not specified in the `fields` argument.
            allowed = set(fields)
            existing = set(self.fields.keys())
            for field_name in existing - allowed:
                self.fields.pop(field_name)


class CountrySerializer(DynamicFieldsModelSerializer, TranslatableModelSerializer):
    code_2 = serializers.CharField(max_length=2, required=True)
    code_3 = serializers.CharField(max_length=3, required=True)
    name = serializers.CharField(max_length=100, required=True)
    latitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    longitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)

    class Meta:
        model = Country
        fields = ('code_2', 'code_3', 'name', 'region', 'sub_region', 'intermediate_region', 'latitude', 'longitude')


class AreaSerializer(DynamicFieldsModelSerializer, TranslatableModelSerializer):
    id = serializers.IntegerField(read_only=True)
    parent = serializers.PrimaryKeyRelatedField(queryset=Area.objects.all(), allow_null=True, required=False)
    created_by = DisplayUserSerializer(read_only=True)
    approved_by = DisplayUserSerializer(read_only=True)
    created_on = serializers.DateTimeField(read_only=True)
    approved_on = serializers.DateTimeField(read_only=True)

    has_subareas = serializers.BooleanField(read_only=True)
    has_routes = serializers.BooleanField(read_only=True)

    name = serializers.CharField(max_length=100, required=True)
    info = serializers.CharField(required=True)
    latitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    longitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    size = serializers.FloatField(required=True)

    def validate_parent(self, value):
        parent_id = self.context['view'].kwargs['id']

        # elif not region.active:
        #     raise serializers.ValidationError("Selected region is not available anymore.")
        if value is None or value.id != parent_id:
            raise serializers.ValidationError("Inconsistent data parent id in payload does not match the one from the query")

        return value

    def create(self, validated_data):
        # TODO: Area admin check
        pdb.set_trace()
        request = self.context['request']
        user = request.user

        parent = None
        country = None
        if 'parent' in validated_data:
            parent = validated_data.get('parent')
            country = parent.country

        area = Area.objects.create(created_by=user, country=country, **validated_data)

        # Set the user that creates and area as it's admin
        area.admins.add(user)
        area.save()

        return area

    class Meta:
        model = Area
        fields = ('id', 'parent', 'country', 'name', 'info', 'approach', 'history',
            'ethics', 'accomodations', 'restrictions', 'descent', 'latitude', 'longitude',
            'size', 'created_on', 'approved_on', 'created_by', 'approved_by', 'tags',
            'has_subareas', 'has_routes')


class RouteSerializer(DynamicFieldsModelSerializer, TranslatableModelSerializer):
    id = serializers.IntegerField(read_only=True)
    created_by = DisplayUserSerializer(read_only=True)
    approved_by = DisplayUserSerializer(read_only=True)
    created_on = serializers.DateTimeField(read_only=True)
    approved_on = serializers.DateTimeField(read_only=True)
    schema_256 = serializers.ImageField(read_only=True)
    schema_2048 = serializers.ImageField(read_only=True)
    schema_1024 = serializers.ImageField(read_only=True)
    schema_full = serializers.ImageField(read_only=True)

    name = serializers.CharField(max_length=100, required=True)
    info = serializers.CharField(required=True)
    latitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    longitude = serializers.DecimalField(required=True, max_digits=25, decimal_places=20)
    area_id = serializers.IntegerField(required=True)
    type = serializers.ChoiceField(choices=RouteType.ROUTE_TYPE_CHOICES, required=True)

    schema_base_64 = serializers.CharField(required=False)
    schema_filename = serializers.CharField(required=False)
    schema_content_type = serializers.CharField(required=False)

    def validate_area_id(self, value):
        area_id = self.context['view'].kwargs['id']
        area = Area.objects.get(id=area_id)

        if area is None:
            raise serializers.ValidationError("Sector not found.")
        # elif not sector.active:
        #     raise serializers.ValidationError("Selected sector is not available anymore.")
        elif value != area_id:
            raise serializers.ValidationError("Inconsistent data area id in payload does not match the one from the query")

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
        fields = ('id', 'area_id', 'name', 'info', 'rating', 'type', 'difficulty', 'rating',
            'length', 'type', 'schema', 'schema_full', 'schema_256', 'schema_1024', 'schema_2048', 'latitude', 'longitude',
            'created_on', 'approved_on', 'created_by', 'approved_by', 'tags', 'schema_base_64',
            'schema_filename', 'schema_content_type')


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