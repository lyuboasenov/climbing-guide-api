from django.db import models

# Create your models here.
class Language:
    AvailableLanguages = [
        {'code': 'en', 'name': 'English', 'default': True},
        {'code': 'bg', 'name': 'Български', 'default': False},
        {'code': 'fr', 'name': 'Français', 'default': False},
        {'code': 'es', 'name': 'Español', 'default': False},
        {'code': 'it', 'name': 'Italiano', 'default': False},
        {'code': 'nl', 'name': 'Nederlands', 'default': False}
    ]


class NewsFeed:
    NewsSources = [
        {'name': 'climbingguidebg', 'url': 'https://www.climbingguidebg.com/index.php?module=News&type=user&func=view&theme=RSS'},
        {'name': '8a', 'url': 'https://www.8a.nu/rss/Main.aspx?CountryCode=GLOBAL'},
    ]