from rest_framework.viewsets import ModelViewSet
from rest_framework.views import APIView

from .models import Region, Area, Sector, Route

from .serializers import RegionSerializer, AreaSerializer, SectorSerializer, RouteSerializer, GradeSerializer, GradeSystemListSerializer

from rest_framework.permissions import IsAuthenticatedOrReadOnly
from rest_framework.decorators import list_route
from django.utils.decorators import method_decorator
from rest_framework.response import Response
from rest_framework.pagination import PageNumberPagination

from drf_yasg.utils import swagger_auto_schema
from drf_yasg import openapi

from .grades import Grade, GradeSystem

# import pdb; pdb.set_trace()

# translatable_param = openapi.Parameter('lang',
#     openapi.IN_PATH,
#     description="Represents the language in which the resource fields to be returned. Defaults to en",
#     type=openapi.TYPE_STRING)
fields_param = openapi.Parameter('fields',
    openapi.IN_QUERY,
    description="Represents a list of resource fields to be served. If not specified all fields are returned.",
    type=openapi.TYPE_STRING)
light_param = openapi.Parameter('light',
    openapi.IN_QUERY,
    description="Specified that short list of resource's fields to be served.",
    type=openapi.TYPE_BOOLEAN)

class LargeResultsSetPagination(PageNumberPagination):
    page_size = 100
    page_size_query_param = 'page_size'
    max_page_size = 1000

@method_decorator(name = 'list', decorator = swagger_auto_schema(
    operation_description = "Returns list of all regions",
    manual_parameters = [fields_param, light_param]
))
@method_decorator(name = 'retrieve', decorator = swagger_auto_schema(
    operation_description = "Returns a partucular region",
    manual_parameters = [fields_param, light_param]
))
@method_decorator(name = 'create', decorator = swagger_auto_schema(
    operation_description = "Create new region"
))
@method_decorator(name = 'update', decorator = swagger_auto_schema(
    operation_description = "Update a partucular region"
))
@method_decorator(name = 'destroy', decorator = swagger_auto_schema(
    operation_description = "Removes a partucular region"
))
class RegionView(ModelViewSet):
    """
    View set for viewing and editing regions.
    """
    queryset = Region.objects.filter(active=True).order_by('translations__name')
    serializer_class = RegionSerializer
    permission_classes = [IsAuthenticatedOrReadOnly]
    pagination_class = LargeResultsSetPagination


@method_decorator(name = 'list', decorator = swagger_auto_schema(
    operation_description = "Returns list of all areas for a given region",
    manual_parameters = [fields_param, light_param]
))
@method_decorator(name = 'retrieve', decorator = swagger_auto_schema(
    operation_description = "Returns a partucular area",
    manual_parameters = [fields_param, light_param]
))
@method_decorator(name = 'create', decorator = swagger_auto_schema(
    operation_description = "Create new area"
))
@method_decorator(name = 'update', decorator = swagger_auto_schema(
    operation_description = "Update a partucular area"
))
@method_decorator(name = 'destroy', decorator = swagger_auto_schema(
    operation_description = "Removes a partucular area"
))
class AreaView(ModelViewSet):
    """
    View set for viewing and editing area.
    """
    queryset = Area.objects.filter(active=True).order_by('translations__name')
    serializer_class = AreaSerializer
    permission_classes = [IsAuthenticatedOrReadOnly]
    pagination_class = LargeResultsSetPagination

    @list_route()
    def list(self, request, region=None):
        queryset = self.queryset.filter(region__id=region)
        page = self.paginate_queryset(queryset)

        if page is not None:
            serializer = self.get_serializer(page, many=True)
            return self.get_paginated_response(serializer.data)

        serializer = self.get_serializer(queryset, many=True)
        return Response(serializer.data)


@method_decorator(name = 'list', decorator = swagger_auto_schema(
    operation_description = "Returns list of all sectors for a given area",
    manual_parameters = [fields_param, light_param]
))
@method_decorator(name = 'retrieve', decorator = swagger_auto_schema(
    operation_description = "Returns a partucular sector",
    manual_parameters = [fields_param, light_param]
))
@method_decorator(name = 'create', decorator = swagger_auto_schema(
    operation_description = "Create new sector"
))
@method_decorator(name = 'update', decorator = swagger_auto_schema(
    operation_description = "Update a partucular sector"
))
@method_decorator(name = 'destroy', decorator = swagger_auto_schema(
    operation_description = "Removes a partucular sector"
))
class SectorView(ModelViewSet):
    """
    View set for viewing and editing sector.
    """
    queryset = Sector.objects.filter(active=True).order_by('translations__name')
    serializer_class = SectorSerializer
    permission_classes = [IsAuthenticatedOrReadOnly]
    pagination_class = LargeResultsSetPagination

    @list_route()
    def list(self, request, area=None):
        queryset = self.queryset.filter(area__id=area)
        page = self.paginate_queryset(queryset)

        if page is not None:
            serializer = self.get_serializer(page, many=True)
            return self.get_paginated_response(serializer.data)

        serializer = self.get_serializer(queryset, many=True)
        return Response(serializer.data)


@method_decorator(name = 'list', decorator = swagger_auto_schema(
    operation_description = "Returns list of all routes for a given sector",
    manual_parameters = [fields_param, light_param]
))
@method_decorator(name = 'retrieve', decorator = swagger_auto_schema(
    operation_description = "Returns a partucular route",
    manual_parameters = [fields_param, light_param]
))
@method_decorator(name = 'create', decorator = swagger_auto_schema(
    operation_description = "Create new route"
))
@method_decorator(name = 'update', decorator = swagger_auto_schema(
    operation_description = "Update a partucular route"
))
@method_decorator(name = 'destroy', decorator = swagger_auto_schema(
    operation_description = "Removes a partucular route"
))
class RouteView(ModelViewSet):
    """
    View set for viewing and editing route.
    """
    queryset = Route.objects.filter(active=True).order_by('translations__name')
    serializer_class = RouteSerializer
    permission_classes = [IsAuthenticatedOrReadOnly]
    pagination_class = LargeResultsSetPagination

    @list_route()
    def list(self, request, sector=None):
        queryset = self.queryset.filter(sector__id=sector)
        page = self.paginate_queryset(queryset)

        if page is not None:
            serializer = self.get_serializer(page, many=True)
            return self.get_paginated_response(serializer.data)

        serializer = self.get_serializer(queryset, many=True)
        return Response(serializer.data)



class GradeView(APIView):
    """
    Returns list of all grades by the given system.
    """
    def get(self, request, system):
        data = Grade.GRADE_LIST[system]
        serializer = GradeSerializer(data, many=True)
        return Response(serializer.data)

    def get_serializer(self):
        return GradeSerializer(many=True)


class GradeSystemView(APIView):
    """
    Returns a list of grade systems by route type.
    """
    def get(self, request):
        data = GradeSystem.GRADE_SYSTEM_LIST
        serializer = GradeSystemListSerializer(data, many=True)
        return Response(serializer.data)

    def get_serializer(self):
        return GradeSystemListSerializer()