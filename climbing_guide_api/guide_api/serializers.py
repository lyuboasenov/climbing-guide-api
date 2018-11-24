from rest_framework import serializers
from parler_rest.serializers import TranslatableModelSerializer, TranslatedFieldsField
from .models import Region, Area, Sector, Route
from django.contrib.auth.models import User


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
    created_by = DisplayUserSerializer(read_only=True)
    approved_by = DisplayUserSerializer(read_only=True)
    name = serializers.CharField(max_length=100, required=True)
    info = serializers.CharField(required=True)

    light_fields = ('id', 'name', 'info', 'latitude', 'longitude', 'size', 'country_code')

    def create(self, validated_data):
        user = self.context['request'].user
        region = Region.objects.create(created_by = user, **validated_data)

        return region

    class Meta:
        model = Region
        fields = ('id', 'name', 'info', 'restrictions', 'latitude',
            'longitude', 'size', 'created_on', 'approved_on', 'created_by',
            'approved_by', 'country_code', 'tags')


class AreaSerializer(DynamicFieldsModelSerializer, TranslatableModelSerializer):
    created_by = DisplayUserSerializer(read_only=True)
    approved_by = DisplayUserSerializer(read_only=True)
    name = serializers.CharField(max_length=100, required=True)
    info = serializers.CharField(required=True)
    region_id = serializers.IntegerField(required=True)

    light_fields = ('id', 'region_id', 'name', 'info', 'latitude', 'longitude', 'size')

    class Meta:
        model = Area
        fields = ('id', 'region_id', 'name', 'info', 'restrictions', 'access', 'descent',
            'latitude', 'longitude', 'size', 'created_on', 'approved_on', 'created_by',
            'approved_by', 'tags')


class SectorSerializer(DynamicFieldsModelSerializer, TranslatableModelSerializer):
    created_by = DisplayUserSerializer(read_only=True)
    approved_by = DisplayUserSerializer(read_only=True)
    name = serializers.CharField(max_length=100, required=True)
    info = serializers.CharField(required=True)
    area_id = serializers.IntegerField(required=True)

    light_fields = ('id', 'area_id', 'name', 'info', 'latitude', 'longitude', 'size')

    class Meta:
        model = Sector
        fields = ('id', 'area_id', 'name', 'info', 'access', 'descent',
            'latitude', 'longitude', 'size', 'created_on', 'approved_on', 'created_by',
            'approved_by', 'tags')


class RouteSerializer(DynamicFieldsModelSerializer, TranslatableModelSerializer):
    created_by = DisplayUserSerializer(read_only=True)
    approved_by = DisplayUserSerializer(read_only=True)
    name = serializers.CharField(max_length=100, required=True)
    info = serializers.CharField(required=True)
    sector_id = serializers.IntegerField(required=True)

    light_fields = ('id', 'sector_id', 'name', 'info', 'difficulty', 'rating', 'type',
            'schemaThumb256', 'schemaThumb2048', 'latitude', 'longitude')

    class Meta:
        model = Route
        fields = ('id', 'sector_id', 'name', 'info', 'fa', 'difficulty', 'rating', 'length', 'type',
            'schema', 'schemaThumb256', 'schemaThumb2048', 'latitude', 'longitude', 'created_on',
            'approved_on', 'created_by', 'approved_by', 'tags')


class GradeSerializer(serializers.Serializer):
    type = serializers.IntegerField(read_only=True)
    value = serializers.IntegerField(read_only=True)
    name = serializers.CharField(read_only=True)


class GradeSystemSerializer(serializers.Serializer):
    id = serializers.IntegerField(read_only=True)
    name = serializers.CharField(read_only=True)


class GradeSystemListSerializer(serializers.Serializer):
    routeType = serializers.IntegerField(read_only=True)
    gradeSystems = GradeSystemSerializer(read_only=True, many=True)