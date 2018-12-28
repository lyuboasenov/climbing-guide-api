from django.contrib import admin

from .models import Area, Route
from parler.admin import TranslatableAdmin, TranslatableStackedInline


class AreaAdmin(TranslatableAdmin):
    pass


class RouteAdmin(TranslatableAdmin):
    pass


admin.site.register(Area, AreaAdmin)
admin.site.register(Route, RouteAdmin)
