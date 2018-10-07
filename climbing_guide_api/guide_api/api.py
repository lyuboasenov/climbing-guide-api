from rest_framework.generics import ListAPIView

from .serializers import RegionSerializer, AreaSerializer, SectorSerializer, RouteSerializer
from .models import Region, Area, Sector, Route

class RegionApi(ListAPIView):
    """
    Return a list of all the existing regions.
    """
    queryset = Region.objects.all()
    serializer_class = RegionSerializer


class AreaApi(ListAPIView):
    """
    Return a list of all the areas filtered by a given region.
    """
    serializer_class = AreaSerializer
    
    def get_queryset(self):
        region = self.kwargs['region']
        return Area.objects.filter(region__id=region)


class SectorApi(ListAPIView):
    """
    Return a list of all the sectors filtered by a given area.
    """
    serializer_class = SectorSerializer
    
    def get_queryset(self):
        area = self.kwargs['area']
        return Sector.objects.filter(area__id=area)


class RouteApi(ListAPIView):
    """
    Return a list of all the routes filtered by a given area.
    """
    queryset = Route.objects.all()
    serializer_class = RouteSerializer
    
    def get_queryset(self):
        sector = self.kwargs['sector']
        return Route.objects.filter(sector__id=sector)