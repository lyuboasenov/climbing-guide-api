from rest_framework.generics import ListAPIView

from .serializers import RegionSerializer, AreaSerializer, SectorSerializer, RouteSerializer
from .models import Region, Area, Sector, Route

class RegionApi(ListAPIView):
    queryset = Region.objects.all()
    serializer_class = RegionSerializer


class AreaApi(ListAPIView):
    serializer_class = AreaSerializer
    
    def get_queryset(self):
        region = self.kwargs['region']
        return Area.objects.filter(region__id=region)


class SectorApi(ListAPIView):
    serializer_class = SectorSerializer
    
    def get_queryset(self):
        area = self.kwargs['area']
        return Sector.objects.filter(area__id=area)


class RouteApi(ListAPIView):
    queryset = Route.objects.all()
    serializer_class = RouteSerializer
    
    def get_queryset(self):
        sector = self.kwargs['sector']
        return Route.objects.filter(sector__id=sector)