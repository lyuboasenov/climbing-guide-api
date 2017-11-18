from django.contrib import admin

from .models import Region, Area, Sector, Route
from parler.admin import TranslatableAdmin, TranslatableStackedInline


class RegionAdmin(TranslatableAdmin):
    pass


class AreaAdmin(TranslatableAdmin):
    pass


class SectorAdmin(TranslatableAdmin):
    pass


class RouteAdmin(TranslatableAdmin):
    pass


admin.site.register(Region, RegionAdmin)
admin.site.register(Area, AreaAdmin)
admin.site.register(Sector, SectorAdmin)
admin.site.register(Route, RouteAdmin)
