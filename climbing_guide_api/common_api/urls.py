from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'users$', views.UserCreateApi.as_view(), name='account-create'),
    url(r'languages$', views.LanguagesView.as_view(), name='list-languages'),
]
