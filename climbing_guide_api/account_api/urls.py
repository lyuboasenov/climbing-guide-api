from django.conf.urls import url
from . import api

urlpatterns = [
    url(r'users$', api.UserCreateApi.as_view(), name='account-create'),
]
