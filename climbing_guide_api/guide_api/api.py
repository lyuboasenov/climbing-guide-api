from rest_framework.generics import ListAPIView

from .serializers import RegionSerializer, AreaSerializer, SectorSerializer, RouteSerializer
from .models import Region, Area, Sector, Route

class RegionApi(ListAPIView):
    queryset = Region.objects.all()
    serializer_class = RegionSerializer


class AreaApi(ListAPIView):
    queryset = Area.objects.all()
    serializer_class = AreaSerializer


class SectorApi(ListAPIView):
    queryset = Sector.objects.all()
    serializer_class = SectorSerializer


class RouteApi(ListAPIView):
    queryset = Route.objects.all()
    serializer_class = RouteSerializer