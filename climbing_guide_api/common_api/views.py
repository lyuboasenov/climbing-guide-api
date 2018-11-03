from rest_framework.views import APIView
from rest_framework.response import Response
from rest_framework import status
from common_api.serializers import UserSerializer, LanguageSerializer
from django.contrib.auth.models import User

class UserCreateApi(APIView):
    """
    post:
    Creates an user account. 
    """

    def get_serializer(self):
        return UserSerializer()

    def post(self, request, format='json'):
        serializer = UserSerializer(data=request.data)
        if serializer.is_valid():
            user = serializer.save()
            if user:
                return Response(serializer.data, status=status.HTTP_201_CREATED)
            
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)


class LanguagesView(APIView):
    def get(self, request):
        data = [
            {'code': 'en', 'name': 'English', 'default': True},
            {'code': 'bg', 'name': 'Български', 'default': False},
            {'code': 'fr', 'name': 'Français', 'default': False},
            {'code': 'es', 'name': 'Español', 'default': False},
            {'code': 'it', 'name': 'Italiano', 'default': False},
            {'code': 'nl', 'name': 'Nederlands', 'default': False}
        ]
        serializer = LanguageSerializer(data, many=True)
        return Response(serializer.data)

    def get_serializer(self):
        return LanguageSerializer()
