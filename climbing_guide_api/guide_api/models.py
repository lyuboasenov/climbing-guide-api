from django.db import models
from django.contrib.auth.models import User
from parler.models import TranslatableModel, TranslatedFields
from enumchoicefield import ChoiceEnum, EnumChoiceField

from PIL import Image, ExifTags
from io import BytesIO
from django.core.files.uploadedfile import SimpleUploadedFile
import os
from imagekit.models import ImageSpecField
from imagekit.processors import ResizeToFit, Transpose

#Abstract classes
class RevisionableModel(models.Model):
    previous = models.ForeignKey('self', related_name='revision_previous', null=True, blank=True, on_delete=models.DO_NOTHING)
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
class Country(GeoModel, TranslatableModel):
    translations = TranslatedFields(
        name = models.CharField(max_length=100),
        region = models.CharField(max_length=100, blank=True),
        sub_region = models.CharField(max_length=100, blank=True),
        intermediate_region = models.CharField(max_length=100, blank=True),
    )
    code_2 = models.CharField(max_length=2, default='BG')
    code_3 = models.CharField(max_length=3, default='BGR')

    class Meta:
        verbose_name = "Country"
        verbose_name_plural = "Countries"

    def __unicode__(self):
        return super().name

    def __str__(self):
        # Fetching the title just works, as all
        # attributes are proxied to the translated model.
        # Fallbacks are handled as well.
        return "{0}".format(self.name)


class Area(GeoSizableModel, RevisionableModel, TranslatableModel):
    parent = models.ForeignKey('self', related_name='area_children', null=True, blank=True, on_delete=models.DO_NOTHING)
    country = models.ForeignKey(Country, null=True, blank=True, on_delete=models.DO_NOTHING)
    translations = TranslatedFields(
        name = models.CharField(max_length=100),
        info = models.TextField(),
        approach = models.TextField(blank=True, default=''),
        history = models.TextField(blank=True, default=''),
        ethics = models.TextField(blank=True, default=''),
        accomodations = models.TextField(blank=True, default=''),
        restrictions = models.TextField(blank=True, default=''),
        descent = models.TextField(blank=True, default=''),
    )
    #overloads in order to change related_name
    created_by = models.ForeignKey(User, related_name='area_create_by', on_delete=models.PROTECT)
    approved_by = models.ForeignKey(User, related_name='area_approved_by', on_delete=models.PROTECT, blank=True, null=True)
    admins =  models.ManyToManyField(User)
    tags = models.TextField(default='', null=True, blank=True)

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
    area = models.ForeignKey(Area, related_name='route_area', null=True, blank=True, on_delete=models.CASCADE)
    difficulty = models.PositiveSmallIntegerField()
    rating = models.PositiveSmallIntegerField(default = 0)
    length = models.PositiveSmallIntegerField(blank=True, default='0')
    translations = TranslatedFields(
        name = models.CharField(max_length=100),
        info = models.TextField(),
        approach = models.TextField(blank=True, default=''),
        history = models.TextField(blank=True, default=''),
    )
    #overloads in order to change related_name
    created_by = models.ForeignKey(User, related_name='route_create_by', on_delete=models.PROTECT)
    approved_by = models.ForeignKey(User, related_name='route_approved_by', on_delete=models.PROTECT, blank=True, null=True)
    type = models.SmallIntegerField(
        choices=RouteType.ROUTE_TYPE_CHOICES,
        default=RouteType.BOULDER
        )
    topo = models.TextField(default='', null=True, blank=True)
    schema =  models.ImageField(upload_to='images/routes/schema/%Y/%m/%d/', blank=True)
    schema_256 = ImageSpecField(source='schema',
                                      processors=[Transpose(Transpose.AUTO), ResizeToFit(256, 256)],
                                      format='JPEG',
                                      options={'quality': 60})
    schema_1024 = ImageSpecField(source='schema',
                                      processors=[Transpose(Transpose.AUTO), ResizeToFit(2048, 2048)],
                                      format='JPEG',
                                      options={'quality': 60})
    schema_2048 = ImageSpecField(source='schema',
                                      processors=[Transpose(Transpose.AUTO), ResizeToFit(2048, 2048)],
                                      format='JPEG',
                                      options={'quality': 60})
    schema_full = ImageSpecField(source='schema',
                                      processors=[Transpose(Transpose.AUTO)],
                                      format='JPEG',
                                      options={'quality': 60})
    tags = models.TextField(default='', null=True, blank=True)

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