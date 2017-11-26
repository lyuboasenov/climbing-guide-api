from django.conf.urls import url
from . import api

urlpatterns = [
    url(r'register$', api.UserCreateApi.as_view(), name='account-create'),
]
