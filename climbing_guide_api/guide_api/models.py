from django.db import models
from django.contrib.auth.models import User
from parler.models import TranslatableModel, TranslatedFields

#Abstract classes
class RevisionableModel(models.Model):
    parent = models.PositiveIntegerField(blank=True, default='0')
    revision = models.PositiveIntegerField(default=1)
    created_on = models.DateTimeField(auto_now_add=True)
    created_by = models.ForeignKey(User, related_name='create_by')
    approved_by = models.ForeignKey(User, related_name='approved_by')
    approved_on = models.DateTimeField(null=True)
    active = models.BooleanField(default=True)
    
    class Meta:
        abstract = True

class GeoModel(models.Model):
    longitude = models.DecimalField(max_digits=9, decimal_places=7)
    latitude = models.DecimalField(max_digits=9, decimal_places=7)
    
    class Meta:
        abstract = True
    
class GeoSizableModel(GeoModel):
    size = models.DecimalField(max_digits=10, decimal_places=6)
    
    class Meta:
        abstract = True

#Model classes
class Region(GeoSizableModel, RevisionableModel, TranslatableModel):
    translations = TranslatedFields(
        name = models.CharField(max_length=100),
        info = models.TextField(),
        restrictions = models.TextField(blank=True),
    )
    #overloads in order to change related_name
    created_by = models.ForeignKey(User, related_name='region_create_by')
    approved_by = models.ForeignKey(User, related_name='region_approved_by')

    class Meta:
        verbose_name = "Region"
        verbose_name_plural = "Regions"
        
    def __unicode__(self):
        return super().name
    
    def __str__(self):
        # Fetching the title just works, as all
        # attributes are proxied to the translated model.
        # Fallbacks are handled as well.
        return "{0}".format(self.name)


class Area(GeoSizableModel, RevisionableModel, TranslatableModel):
    region = models.ForeignKey(Region, on_delete=models.CASCADE)
    translations = TranslatedFields(
        name = models.CharField(max_length=100),
        info = models.TextField(),
        restrictions = models.TextField(blank=True, default=''),
        access = models.TextField(blank=True, default=''),
        descent = models.TextField(blank=True, default=''),
    )
    #overloads in order to change related_name
    created_by = models.ForeignKey(User, related_name='area_create_by')
    approved_by = models.ForeignKey(User, related_name='area_approved_by')

    class Meta:
        verbose_name = "Area"
        verbose_name_plural = "Areas"
        
    def __unicode__(self):
        return super().name
    
    def __str__(self):
        # Fetching the title just works, as all
        # attributes are proxied to the translated model.
        # Fallbacks are handled as well.
        return "{0}".format(self.name)


class Sector(GeoSizableModel, RevisionableModel, TranslatableModel):
    area = models.ForeignKey(Area, on_delete=models.CASCADE)
    translations = TranslatedFields(
        name = models.CharField(max_length=100),
        info = models.TextField(),
        access = models.TextField(blank=True, default=''),
        descent = models.TextField(blank=True, default=''),
    )
    #overloads in order to change related_name
    created_by = models.ForeignKey(User, related_name='sector_create_by')
    approved_by = models.ForeignKey(User, related_name='sector_approved_by')
    
    class Meta:
        verbose_name = "Sector"
        verbose_name_plural = "Sectors"
        
    def __unicode__(self):
        return super().name
    
    def __str__(self):
        # Fetching the title just works, as all
        # attributes are proxied to the translated model.
        # Fallbacks are handled as well.
        return "{0}".format(self.name)
    

class RouteType():
    BOULDER = 1
    SPORT = 2
    TRAD = 4
    ROUTE_TYPE_CHOICES = (
        (BOULDER, "Boulder"),
        (SPORT, "Sport"),
        (TRAD, "Trad"),
    )


class Route(GeoModel, RevisionableModel, TranslatableModel):
    sector = models.ForeignKey(Sector, on_delete=models.CASCADE)
    difficulty = models.PositiveSmallIntegerField()
    rating = models.PositiveSmallIntegerField(default = 0)
    length = models.PositiveSmallIntegerField(blank=True, default='0')
    translations = TranslatedFields(
        name = models.CharField(max_length=100),
        info = models.TextField(),
        fa = models.CharField(max_length=200, blank=True, default=''),
    )
    type = models.SmallIntegerField(
        choices=RouteType.ROUTE_TYPE_CHOICES,
        default=RouteType.BOULDER
        )
    schema =  models.FileField(upload_to='routes/schema/%Y/%m/%d/')
    #overloads in order to change related_name
    created_by = models.ForeignKey(User, related_name='route_create_by')
    approved_by = models.ForeignKey(User, related_name='route_approved_by')
    
    class Meta:
        verbose_name = "Route"
        verbose_name_plural = "Routes"
        
    def __unicode__(self):
        return super().name
    
    def __str__(self):
        # Fetching the title just works, as all
        # attributes are proxied to the translated model.
        # Fallbacks are handled as well.
        return "{0}".format(self.name)
        