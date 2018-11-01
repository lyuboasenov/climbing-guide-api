from rest_framework import serializers
from parler_rest.serializers import TranslatableModelSerializer, TranslatedFieldsField
from .models import Region, Area, Sector, Route
from django.contrib.auth.models import User


class DisplayUserSerializer(serializers.ModelSerializer):

    class Meta:
        model = User
        fields = ('id', 'username')


class RegionSerializer(TranslatableModelSerializer):
    # translations = TranslatedFieldsField(shared_model=Region)
    created_by = DisplayUserSerializer(read_only=True)
    approved_by = DisplayUserSerializer(read_only=True)
    name = serializers.CharField(max_length=100, required=True)
    info = serializers.CharField(required=True)

    class Meta:
        model = Region
        fields = ('id', 'name', 'info', 'restrictions', 'latitude',
            'longitude', 'size', 'created_on', 'approved_on', 'created_by',
            'approved_by')


class AreaSerializer(TranslatableModelSerializer):
    #translations = TranslatedFieldsField(shared_model=Area)

    class Meta:
        model = Area
        fields = ('id', 'name', 'info', 'latitude', 'longitude', 'size')


class SectorSerializer(TranslatableModelSerializer):
    #translations = TranslatedFieldsField(shared_model=Sector)

    class Meta:
        model = Sector
        fields = ('id', 'name', 'info', 'latitude', 'longitude', 'size')


class RouteSerializer(TranslatableModelSerializer):
    #translations = TranslatedFieldsField(shared_model=Route)

    class Meta:
        model = Route
        fields = ('id', 'name', 'info', 'difficulty', 'rating', 'schema', 'schemaThumb256', 'latitude', 'longitude', 'type')
