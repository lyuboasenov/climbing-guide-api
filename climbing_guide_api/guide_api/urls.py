from django.conf.urls import url
from django.urls import path

from .views import RegionView, AreaView, SectorView, RouteView

urlpatterns = [
    path('regions', RegionView.as_view({'get': 'list', 'post': 'create'})),
    path('regions/<int:pk>', RegionView.as_view({'get': 'retrieve', 'put': 'update', 'patch': 'update', 'delete': 'destroy'})),
    
    path('regions/<int:region>/areas', AreaView.as_view({'get': 'list', 'post': 'create'})),
    path('areas/<int:pk>', AreaView.as_view({'get': 'retrieve', 'put': 'update', 'patch': 'update', 'delete': 'destroy'})),

    path('areas/<int:area>/sectors', AreaView.as_view({'get': 'list', 'post': 'create'})),
    path('sectors/<int:pk>', AreaView.as_view({'get': 'retrieve', 'put': 'update', 'patch': 'update', 'delete': 'destroy'})),

    path('sectors/<int:sector>/routes', AreaView.as_view({'get': 'list', 'post': 'create'})),
    path('routes/<int:pk>', AreaView.as_view({'get': 'retrieve', 'put': 'update', 'patch': 'update', 'delete': 'destroy'})),
]
