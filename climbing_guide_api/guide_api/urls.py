from django.conf.urls import url

from .api import RegionApi, AreaApi, SectorApi, RouteApi

urlpatterns = [
    url(r'^regions$', RegionApi.as_view()),
    url(r'^areas$', AreaApi.as_view()),
    url(r'^sectors$', SectorApi.as_view()),
    url(r'^routes$', RouteApi.as_view()),
]
