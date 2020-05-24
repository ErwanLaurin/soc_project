# Projet SOC Let's go biking!  

Erwan Laurin  

## État du projet  

### Structure  

+ CacheService (WS self-hosted qui limite les requêtes vers l'API JCDecaux)   
+ RouteService (WS self-hosted qui calcule un itinéraire entre 2 adresses, appelle CacheService et plusieurs API Google)  
+ Client (Client WinForms, appelle RouteService)  

### Description  

Après lancement de CacheService et de RouteService, on lance le client : une combo box propose les contrats disponibles (récupérés par CacheService). Lors de la sélection d'un contrat, le cache récupère les données des stations correspondant au contrat choisi. Le cache ne s'actualise ensuite que lorsque la dernière requête date de plus d'une minute, ou lorsque l'on sélectionne un autre contrat.  

On entre ensuite une adresse de départ et une adresse de destintation, et on clique sur "Rechercher un itinéraire". RouteService va alors calculer un itinéraire entre ces deux adresses et en prenant en compte les stations de vélos disponibles, à l'aide de l'API Google Distance Matrix : RouteService va alors trouver les stations les plus proches des points de départ et de destination pour retourner l'itinéraire le plus adapté. Ainsi l'itinéraire sera composé d'une étape à pied jusqu'à la station la plus proche, d'une étape à vélo jusqu'à la station la plus proche de la destination, et d'une dernière étape à pied jusqu'à la destination.  

De plus, RouteService appelle l'API Google Elevation afin d'établir une topologie du trajet à vélo.  

## Ce qui a été fait depuis l'évaluation  

+ Ajout d'une extension : modélisation de la topologie du parcours à vélo (affichage sous forme de graphe de l'évolution de l'altitude).  
+ Amélioration du mode d'actualisation du cache : au lieu de s'actualiser toutes les minutes, le cache ne s'actualise que si une requête est effectuée et que la dernière date de plus d'une minute.  
+ Gestion des grandes villes : si la ville choisie possédait plus de 100 stations de vélo, le programme crashait (requête trop lourde pour l'API Distance Matrix). Ce n'est plus le cas maintenant (traitement de toutes les stations en plusieures requêtes si besoin).  

Une visualisation de l'itinéraire sur une map n'a pas été ajoutée à cause d'un problème de compatibilité entre mon Visual Studio et le package GMap.NET (module n'apparaissant pas dans la toolbox).