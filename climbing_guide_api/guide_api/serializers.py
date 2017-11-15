from rest_framework import serializers

from .models import Region, Area, Sector, Route


class RegionSerializer(serializers.ModelSerializer):

    class Meta:
        model = Region
        fields = '__all__' 


class AreaSerializer(serializers.ModelSerializer):

    class Meta:
        model = Area
        fields = '__all__' 


class SectorSerializer(serializers.ModelSerializer):

    class Meta:
        model = Sector
        fields = '__all__' 


class RouteSerializer(serializers.ModelSerializer):

    class Meta:
        model = Route
        fields = '__all__' 