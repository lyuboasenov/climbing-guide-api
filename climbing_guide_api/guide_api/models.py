from django.db import models
from django.contrib.auth.models import User

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
        
class NameInfoModel(models.Model):
    name = models.CharField(max_length=100)
    info = models.TextField()
    
    class Meta:
        abstract = True

#Model classes
class Region(GeoSizableModel, RevisionableModel, NameInfoModel):
    restrictions = models.TextField(blank=True)
    #overloads in order to change related_name
    created_by = models.ForeignKey(User, related_name='region_create_by')
    approved_by = models.ForeignKey(User, related_name='region_approved_by')

    def __str__(self):
        return super().name


class Area(GeoSizableModel, RevisionableModel, NameInfoModel):
    region = models.ForeignKey(Region)
    restrictions = models.TextField(blank=True, default='')
    access = models.TextField(blank=True, default='')
    descent = models.TextField(blank=True, default='')
    #overloads in order to change related_name
    created_by = models.ForeignKey(User, related_name='area_create_by')
    approved_by = models.ForeignKey(User, related_name='area_approved_by')

    def __str__(self):
        return super().name


class Sector(GeoSizableModel, RevisionableModel, NameInfoModel):
    area = models.ForeignKey(Area)
    access = models.TextField(blank=True, default='')
    descent = models.TextField(blank=True, default='')
    #overloads in order to change related_name
    created_by = models.ForeignKey(User, related_name='sector_create_by')
    approved_by = models.ForeignKey(User, related_name='sector_approved_by')

    def __str__(self):
        return super().name


class RouteType():
    BOULDER = 1
    SPORT = 2
    TRAD = 4
    ROUTE_TYPE_CHOICES = (
        (BOULDER, "Boulder"),
        (SPORT, "Sport"),
        (TRAD, "Trad"),
    )


class Route(GeoModel, RevisionableModel, NameInfoModel):
    sector = models.ForeignKey(Sector)
    difficulty = models.PositiveSmallIntegerField()
    rating = models.PositiveSmallIntegerField(default = 0)
    length = models.PositiveSmallIntegerField(blank=True, default='0')
    fa = models.CharField(max_length=200, blank=True, default='')
    type = models.SmallIntegerField(
        choices=RouteType.ROUTE_TYPE_CHOICES,
        default=RouteType.BOULDER
        )
    schema =  models.FileField(upload_to='routes/schema/%Y/%m/%d/')
    #overloads in order to change related_name
    created_by = models.ForeignKey(User, related_name='route_create_by')
    approved_by = models.ForeignKey(User, related_name='route_approved_by')

    def __str__(self):
        return super().name