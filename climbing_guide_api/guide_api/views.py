from rest_framework.viewsets import ModelViewSet
from rest_framework.generics import ListAPIView

from .models import Region, Area, Sector, Route

from .serializers import RegionSerializer, AreaSerializer, SectorSerializer, RouteSerializer

from rest_framework.permissions import IsAuthenticatedOrReadOnly
from rest_framework.decorators import list_route
from rest_framework.response import Response

# import pdb; pdb.set_trace()

class RegionView(ModelViewSet):
    """
    View set for viewing and editing regions.
    """
    queryset = Region.objects.filter(active=True)
    serializer_class = RegionSerializer
    permission_classes = [IsAuthenticatedOrReadOnly]


class AreaView(ModelViewSet):
    """
    View set for viewing and editing area.
    """
    queryset = Area.objects.filter(active=True)
    serializer_class = AreaSerializer
    permission_classes = [IsAuthenticatedOrReadOnly]

    @list_route()
    def list(self, request, region=None):
        areas = self.queryset.filter(region__id=region)
        serializer = self.get_serializer(areas, many=True)
        return Response(serializer.data)


class SectorView(ModelViewSet):
    """
    View set for viewing and editing sector.
    """
    queryset = Sector.objects.filter(active=True)
    serializer_class = SectorSerializer
    permission_classes = [IsAuthenticatedOrReadOnly]

    @list_route()
    def list(self, request, area=None):
        sectors = self.queryset.filter(area__id=area)
        serializer = self.get_serializer(sectors, many=True)
        return Response(serializer.data)


class RouteView(ModelViewSet):
    """
    View set for viewing and editing route.
    """
    queryset = Route.objects.filter(active=True)
    serializer_class = RouteSerializer
    permission_classes = [IsAuthenticatedOrReadOnly]

    @list_route()
    def list(self, request, sector=None):
        routes = self.queryset.filter(sector__id=sector)
        serializer = self.get_serializer(routes, many=True)
        return Response(serializer.data)