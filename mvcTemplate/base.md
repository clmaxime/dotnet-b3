# Commandes

### dotnet build

### dotnet run
Effectue la compilation, génération des exécutables spécifiques à la machine et lance le programme 

# Fichiers

### .csproj
carte d'identité du projet

### program.cs
C'est le point d'entrée du projet, l'équivalent du main dans d'autres langages

### lauchSettings.json
FIchier de configuration de lancement de l'applicatio

# Fonctionnement application

# Namespace
Pour faciliter réutilisation du code, on importe la classe plutît que de la réécrire pour pouvoir l'utiliser.
Pour faciliter les imports, on utilise des namespace, des contenants virtuels

## Patterne de la route
Strucutre de la route

pattern: "{controller=Name}/{action=Index}/{id}"
Les attributs marqués avec = sont des valeurs par défaut, lors de la visite de l'app avec l'url racine localhost:8000, cela retournera la route du controller Name, action Index


# Performance
Pour des controllers d'API, .NET .NET Core est le plus performant

# COnvention de nommage
## Interfaces
Les noms des interfaces doivent covnentionnellement commencer par un I masjucule