
# Run climbing-guide-api

## Install environment

### Install python

Install Python v3.6.3 (as of Oct. 2018 3.7 has compatibility issues with django)

#### Create virtual environment

```powershell
cd <base-location>
cd python/(win/lin)
python -m venv <virtual-environment-name>
```

#### Install Django and dependencies

```powershell
# Activate previously created virtual environment
cd <base-location>
./<base-location>/python/(win/lin)/<virtual-environment-name>/Scripts/Activate.ps1
# Install Django and dependencies
pip install Django==2.1.2
pip install djangorestframework==3.8.2
pip install django-coreapi==2.3.0
pip install coreapi==2.3.3
pip install django-cors-headers==2.4.0
pip install markdown==3.0.1
pip install django-oauth-toolkit==1.2.0
pip install django-parler==1.9.2
pip install django-parler-rest==2.0.0
pip install Pillow==5.3.0
pip install drf-yasg==1.10.2
```

## Run climbing-guide-api

Run server by using the script

```powershell
cd <base-location>
./runserver.ps1
```

Run server manually

```powershell
cd <base-location>
# Activate previously created virtual environment
./<base-location>/python/(win/lin)/<virtual-environment-name>/Scripts/Activate.ps1
# Start api
climbing_guide_api/manage.py runserver
```