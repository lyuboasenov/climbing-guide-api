from django.conf.urls import url

from .api import RegionApi, AreaApi, SectorApi, RouteApi

urlpatterns = [
    url(r'^regions$', RegionApi.as_view()),
    url(r'^areas/(?P<region>.+)/$', AreaApi.as_view()),
    url(r'^sectors/(?P<area>.+)/$', SectorApi.as_view()),
    url(r'^routes/(?P<sector>.+)/$', RouteApi.as_view()),
]
