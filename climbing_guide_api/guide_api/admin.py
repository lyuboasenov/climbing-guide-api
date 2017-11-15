from django.contrib import admin

from .models import Region, Area, Sector, Route

admin.site.register(Region)
admin.site.register(Area)
admin.site.register(Sector)
admin.site.register(Route)