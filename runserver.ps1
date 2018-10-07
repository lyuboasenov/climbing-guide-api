$rootPath = (split-path $MyInvocation.MyCommand.Definition)
$path = Join-path $rootPath python/win/environment/scripts/activate.ps1

# invoke virtual environment
. $path

climbing_guide_api/manage.py runserver
