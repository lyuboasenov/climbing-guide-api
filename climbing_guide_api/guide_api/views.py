from rest_framework.viewsets import ModelViewSet
from .models import Region, Area, Sector, Route
from .serializers import RegionSerializer, AreaSerializer, SectorSerializer, RouteSerializer
from rest_framework.permissions import IsAdminUser


class RegionViewSet(ModelViewSet):
    """
    View set for viewing and editing regions.
    """
    serializer_class = RegionSerializer

    def get_queryset(self):
        return Region.objects.filter(active=True)

    def get_permissions(self):
        """
        Instantiates and returns the list of permissions that this view requires.
        """
        if self.action == 'list':
            permission_classes = []
        else:
            permission_classes = [IsAdminUser]
        return [permission() for permission in permission_classes]