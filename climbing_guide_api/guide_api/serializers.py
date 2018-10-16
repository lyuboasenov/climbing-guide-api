from rest_framework import serializers
from parler_rest.serializers import TranslatableModelSerializer, TranslatedFieldsField
from .models import Region, Area, Sector, Route


class RegionSerializer(TranslatableModelSerializer):
    #translations = TranslatedFieldsField(shared_model=Region)

    class Meta:
        model = Region
        fields = ('id', 'name', 'info', 'latitude', 'longitude', 'size')


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
        fields = ('id', 'name', 'info', 'difficulty', 'rating', 'schema', 'schemaThumb', 'latitude', 'longitude', 'type')
