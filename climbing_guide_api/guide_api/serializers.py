from rest_framework import serializers
from parler_rest.serializers import TranslatableModelSerializer, TranslatedFieldsField
from .models import Region, Area, Sector, Route


class RegionSerializer(TranslatableModelSerializer):
    translations = TranslatedFieldsField(shared_model=Region)

    class Meta:
        model = Region
        fields = '__all__'


class AreaSerializer(TranslatableModelSerializer):
    translations = TranslatedFieldsField(shared_model=Area)

    class Meta:
        model = Area
        fields = '__all__'


class SectorSerializer(TranslatableModelSerializer):
    translations = TranslatedFieldsField(shared_model=Sector)

    class Meta:
        model = Sector
        fields = '__all__' 


class RouteSerializer(TranslatableModelSerializer):
    translations = TranslatedFieldsField(shared_model=Route)

    class Meta:
        model = Route
        fields = '__all__'