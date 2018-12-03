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

    # def create_thumbnail(self, thumbSize):
    #     # Set our max thumbnail size in a tuple (max width, max height)
    #     # original code for this method came from
    #     # http://snipt.net/danfreak/generate-thumbnails-in-django-with-pil/

    #     # If there is no image associated with this.
    #     # do not create thumbnail
    #     if not self.schema:
    #         return

    #     DJANGO_TYPE = self.schema.file.content_type

    #     if DJANGO_TYPE == 'image/jpeg':
    #         PIL_TYPE = 'jpeg'
    #         FILE_EXTENSION = 'jpg'
    #     elif DJANGO_TYPE == 'image/png':
    #         PIL_TYPE = 'png'
    #         FILE_EXTENSION = 'png'

    #     # Open original photo which we want to thumbnail using PIL's Image
    #     schema = Image.open(BytesIO(self.schema.read()))

    #     if hasattr(schema, '_getexif'): # only present in JPEGs
    #         for orientation in ExifTags.TAGS.keys():
    #             if ExifTags.TAGS[orientation]=='Orientation':
    #                 break
    #         e = schema._getexif()       # returns None if no EXIF data

    #         if e is not None:
    #             exif=dict(e.items())
    #             orientation = exif[orientation]

    #             if orientation == 3:   schema = schema.transpose(Image.ROTATE_180)
    #             elif orientation == 6: schema = schema.transpose(Image.ROTATE_270)
    #             elif orientation == 8: schema = schema.transpose(Image.ROTATE_90)

    #     # We use our PIL Image object to create the thumbnail, which already
    #     # has a thumbnail() convenience method that contrains proportions.
    #     # Additionally, we use Image.ANTIALIAS to make the image look better.
    #     # Without antialiasing the image pattern artifacts may result.
    #     schema.thumbnail(thumbSize, Image.ANTIALIAS)

    #     # Save the thumbnail
    #     temp_handle = BytesIO()
    #     schema.save(temp_handle, PIL_TYPE)
    #     temp_handle.seek(0)

    #     # Save image to a SimpleUploadedFile which can be saved into
    #     # ImageField
    #     suf = SimpleUploadedFile(os.path.split(self.schema.name)[-1],
    #             temp_handle.read(), content_type=DJANGO_TYPE)
    #     # Save SimpleUploadedFile into image field
    #     return ('%s_%s.%s'%(os.path.splitext(suf.name)[0],thumbSize[0],FILE_EXTENSION), suf)

    # def save(self):
    #     # create a thumbnail
    #     thumb256 = self.create_thumbnail((256,256))
    #     self.schemaThumb256.save(thumb256[0], thumb256[1], save=False)

    #     thumb2048 = self.create_thumbnail((2048,2048))
    #     self.schemaThumb2048.save(thumb2048[0], thumb2048[1], save=False)

    #     super(Route, self).save()

    class Meta:
        verbose_name = "Route"
        verbose_name_plural = "Routes"

# class RegionAdmin:
#     person = models.ForeignKey(Person)
#     group = models.ForeignKey(Group)
