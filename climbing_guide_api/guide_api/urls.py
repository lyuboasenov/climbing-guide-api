from django.conf.urls import url
from django.urls import path

from .api import RegionApi, AreaApi, SectorApi, RouteApi
from .views import RegionViewSet

urlpatterns = [
    path('regions', RegionViewSet.as_view({'get': 'list', 'post': 'create'})),
    path('regions/<int:region>/areas', AreaApi.as_view()),
    path('areas/<int:area>/sectors', SectorApi.as_view()),
    path('sectors/<int:sector>/routes', RouteApi.as_view()),
]
