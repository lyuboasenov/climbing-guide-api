from django.conf.urls import url
from django.urls import path

from .views import RegionView, AreaView, SectorView, RouteView, GradeView, GradeSystemView

urlpatterns = [
    path('regions', RegionView.as_view({'get': 'list', 'post': 'create'})),
    path('regions/<int:pk>', RegionView.as_view({'get': 'retrieve', 'put': 'update', 'patch': 'update', 'delete': 'destroy'})),

    path('regions/<int:id>/areas', AreaView.as_view({'get': 'list', 'post': 'create'})),
    path('areas/<int:pk>', AreaView.as_view({'get': 'retrieve', 'put': 'update', 'patch': 'update', 'delete': 'destroy'})),

    path('areas/<int:id>/sectors', SectorView.as_view({'get': 'list', 'post': 'create'})),
    path('sectors/<int:pk>', SectorView.as_view({'get': 'retrieve', 'put': 'update', 'patch': 'update', 'delete': 'destroy'})),

    path('sectors/<int:id>/routes', RouteView.as_view({'get': 'list', 'post': 'create'})),
    path('routes/<int:pk>', RouteView.as_view({'get': 'retrieve', 'put': 'update', 'patch': 'update', 'delete': 'destroy'})),

    path('grades', GradeSystemView.as_view()),
    path('grades/<int:system>', GradeView.as_view())
]
