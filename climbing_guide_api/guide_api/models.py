from django.db import models
from django.contrib.auth.models import User
from parler.models import TranslatableModel, TranslatedFields
from enumchoicefield import ChoiceEnum, EnumChoiceField

from PIL import Image, ExifTags
from io import BytesIO
from django.core.files.uploadedfile import SimpleUploadedFile
import os
from imagekit.models import ImageSpecField
from imagekit.processors import ResizeToFit

#Abstract classes
class RevisionableModel(models.Model):
    parent = models.PositiveIntegerField(blank=True, default='0')
    revision = models.PositiveIntegerField(default=1)
    created_on = models.DateTimeField(auto_now_add=True)
    created_by = models.ForeignKey(User, related_name='create_by', on_delete=models.PROTECT)
    approved_by = models.ForeignKey(User, related_name='approved_by', on_delete=models.PROTECT, blank=True, null=True)
    approved_on = models.DateTimeField(null=True)
    active = models.BooleanField(default=False)
    pending = models.BooleanField(default=True)

    class Meta:
        abstract = True

class GeoModel(models.Model):
    longitude = models.DecimalField(max_digits=25, decimal_places=20)
    latitude = models.DecimalField(max_digits=25, decimal_places=20)

    class Meta:
        abstract = True

class GeoSizableModel(GeoModel):
    size = models.FloatField()

    class Meta:
        abstract = True

#Model classes
class Region(GeoSizableModel, RevisionableModel, TranslatableModel):
    translations = TranslatedFields(
        name = models.CharField(max_length=100),
        info = models.TextField(),
        restrictions = models.TextField(blank=True),
    )
    country_code = models.CharField(max_length=10, default='un')
    #overloads in order to change related_name
    created_by = models.ForeignKey(User, related_name='region_create_by', on_delete=models.PROTECT)
    approved_by = models.ForeignKey(User, related_name='region_approved_by', on_delete=models.PROTECT, blank=True, null=True)
    admins = models.ManyToManyField(User)
    tags = models.TextField(default='')

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
    created_by = models.ForeignKey(User, related_name='area_create_by', on_delete=models.PROTECT)
    approved_by = models.ForeignKey(User, related_name='area_approved_by', on_delete=models.PROTECT, blank=True, null=True)
    admins =  models.ManyToManyField(User)
    tags = models.TextField(default='')

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
    created_by = models.ForeignKey(User, related_name='sector_create_by', on_delete=models.PROTECT)
    approved_by = models.ForeignKey(User, related_name='sector_approved_by', on_delete=models.PROTECT, blank=True, null=True)
    tags = models.TextField(default='')

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
    schema =  models.ImageField(upload_to='images/routes/schema/%Y/%m/%d/', blank=True)
    schema_256 = ImageSpecField(source='schema',
                                      processors=[ResizeToFit(256, 256)],
                                      format='JPEG',
                                      options={'quality': 60})
    schema_2048 = ImageSpecField(source='schema',
                                      processors=[ResizeToFit(2048, 2048)],
                                      format='JPEG',
                                      options={'quality': 60})
    #overloads in order to change related_name
    created_by = models.ForeignKey(User, related_name='route_create_by', on_delete=models.PROTECT)
    approved_by = models.ForeignKey(User, related_name='route_approved_by', on_delete=models.PROTECT, blank=True, null=True)
    tags = models.TextField(default='')

    def __unicode__(self):
        return super().name

    def __str__(self):
        # Fetching the title just works, as all
        # attributes are proxied to the translated model.
        # Fallbacks are handled as well.
        return "{0}".format(self.name)

    class Meta:
        verbose_name = "Route"
        verbose_name_plural = "Routes"