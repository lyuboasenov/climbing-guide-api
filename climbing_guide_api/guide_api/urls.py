from django.conf.urls import url
from django.urls import path

from .views import ParentAreaView, AreaView, RouteView, GradeView, GradeSystemView, CountryView

urlpatterns = [
    path('countries', CountryView.as_view({'get': 'list'})),
    path('countries/<int:pk>', CountryView.as_view({'get': 'retrieve'})),

    path('areas', AreaView.as_view({'get': 'list', 'post': 'create'})),
    path('areas/<int:id>/areas', AreaView.as_view({'get': 'list', 'post': 'create'})),
    # path('areas/<int:id>/parents', ParentAreaView.as_view()),
    path('areas/<int:pk>', AreaView.as_view({'get': 'retrieve', 'put': 'update', 'patch': 'update', 'delete': 'destroy'})),

    path('areas/<int:id>/routes', RouteView.as_view({'get': 'list', 'post': 'create'})),
    path('routes/<int:pk>', RouteView.as_view({'get': 'retrieve', 'put': 'update', 'patch': 'update', 'delete': 'destroy'})),

    path('grades', GradeSystemView.as_view()),
    path('grades/<int:system>', GradeView.as_view())
]
