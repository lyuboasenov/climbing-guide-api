from rest_framework.viewsets import ModelViewSet
from rest_framework.views import APIView

from .models import Area, Route, Country

# from django.db import models
from django.db.models import Count

from .serializers import AreaSerializer, RouteSerializer
from .serializers import GradeSystemListSerializer, GradeSystemSerializer, GradeSerializer
from .serializers import CountrySerializer

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

class LargeResultsSetPagination(PageNumberPagination):
    page_size = 100
    page_size_query_param = 'page_size'
    max_page_size = 1000

@method_decorator(name = 'list', decorator = swagger_auto_schema(
    operation_description = "Returns list of all regions",
    manual_parameters = [fields_param]
))
@method_decorator(name = 'retrieve', decorator = swagger_auto_schema(
    operation_description = "Returns a partucular region",
    manual_parameters = [fields_param]
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
class CountryView(ModelViewSet):
    """
    View set for viewing and editing regions.
    """
    queryset = Country.objects.order_by('translations__name')
    # permission_classes = [IsAuthenticatedOrReadOnly]
    pagination_class = LargeResultsSetPagination
    serializer_class = CountrySerializer


@method_decorator(name = 'list', decorator = swagger_auto_schema(
    operation_description = "Returns list of all areas",
    manual_parameters = [fields_param]
))
@method_decorator(name = 'retrieve', decorator = swagger_auto_schema(
    operation_description = "Returns a partucular area",
    manual_parameters = [fields_param]
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
    queryset = Area.objects.filter(
            active=True
        ).annotate(
            has_subareas=Count('area_children')
        ).annotate(
            has_routes=Count('route_area')
        ).order_by('translations__name')
    permission_classes = [IsAuthenticatedOrReadOnly]
    pagination_class = LargeResultsSetPagination
    serializer_class = AreaSerializer

    @list_route()
    def list(self, request, id=None):
        queryset = self.queryset.filter(parent__id=id)
        page = self.paginate_queryset(queryset)

        if page is not None:
            serializer = self.get_serializer(page, many=True)
            return self.get_paginated_response(serializer.data)

        serializer = self.get_serializer(queryset, many=True)
        return Response(serializer.data)


@method_decorator(name = 'list', decorator = swagger_auto_schema(
    operation_description = "Returns list of all routes for a given area",
    manual_parameters = [fields_param]
))
@method_decorator(name = 'retrieve', decorator = swagger_auto_schema(
    operation_description = "Returns a partucular route",
    manual_parameters = [fields_param]
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
    permission_classes = [IsAuthenticatedOrReadOnly]
    pagination_class = LargeResultsSetPagination
    serializer_class = RouteSerializer

    @list_route()
    def list(self, request, id=None):
        queryset = self.queryset.filter(area__id=id)
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