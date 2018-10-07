# cmd/ps

## Create virtual environment

python -m venv ./win/environment

## Load virtual environment

.\win\environment\scripts\activate.bat

## install django dependencies

pip install django==1.11.7
pip install django-cors-headers==2.1.0
pip install django-oauth-toolkit==1.0.0
pip install django-parler==1.8
pip install django-parler-rest==1.4.2
pip install djangorestframework==3.7.3
pip install Pillow==4.3.0

## run django app

cd ../climbing_guide_api
manage.py runserver