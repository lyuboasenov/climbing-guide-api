from rest_framework.generics import ListAPIView, GenericAPIView
from rest_framework.mixins import ListModelMixin

from .serializers import RegionSerializer, AreaSerializer, SectorSerializer, RouteSerializer
from .models import Region, Area, Sector, Route
from drf_yasg import openapi
from drf_yasg.utils import swagger_auto_schema

class RegionApi(GenericAPIView, ListModelMixin):
    """
    Return a list of all the existing regions.
    """
    queryset=Region.objects.all()

    def filter_queryset(self, queryset):
        queryset.filter(active=True)

    def get_serializer_class(self):
        serializer = RegionSerializer()
        if (self.request.method == 'GET' and self.request.query_params is None):
            serializer = RegionSerializer()
        elif (self.request.method == 'POST'):
            pass
        elif (self.request.method == 'PUT'):
            pass
        elif (self.request.method == 'DELETE'):
            pass
        
        return serializer

    def get(self, request, *args, **kwargs):
        return self.list(request, *args, **kwargs)

class AreaApi(ListAPIView):
    """
    Return a list of all the areas filtered by a given region.
    """
    serializer_class = AreaSerializer
    lookup_field = 'region'
    lookup_url_kwarg = 'region'
    
    def get_queryset(self):
        region = self.kwargs[self.lookup_url_kwarg]
        return Area.objects.filter(region__id=region).filter(active=True)


class SectorApi(ListAPIView):
    """
    Return a list of all the sectors filtered by a given area.
    """
    serializer_class = SectorSerializer
    lookup_field = 'area'
    lookup_url_kwarg = 'area'
    
    def get_queryset(self):
        area = self.kwargs[self.lookup_url_kwarg]
        return Sector.objects.filter(area__id=area)


class RouteApi(ListAPIView):
    """
    Return a list of all the routes filtered by a given sector.
    """
    serializer_class = RouteSerializer
    lookup_field = 'sector'
    lookup_url_kwarg = 'sector'

    # tried to set parameter type -- unsuccessfully
    # @swagger_auto_schema(manual_parameters=[
    #     openapi.Parameter('sector', in_=openapi.IN_QUERY, description='Container sector id', type=openapi.TYPE_INTEGER)
    #     ])
    def get_queryset(self):
        sector = self.kwargs[self.lookup_url_kwarg]
        return Route.objects.filter(sector__id=sector)
