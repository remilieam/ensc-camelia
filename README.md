# Projet d’Intelligence Artificielle – Partie 1

**Gestion des déplacement de chariots dans un entrepôt**

L’utilisateur peut ajouter des chariots dans l’entrepôt (mais pas 
en retirer), sachant que 15 chariots sont déjà placés dans l’entrepôt.
Pour cela, il suffit qu’il clique sur une case blanche de la grille
représentant l’entrepôt.

S’il appuie sur une case noire (représentant une étagère), il ne va rien
se passer.

S’il appuie sur une flèche (représentant un chariot, la flèche pointant
dans la direction de son orientation), cela signifie qu’il veut que le chariot
sur lequel il a cliqué aille chercher un objet spécifique.

Une fenêtre va donc s’ouvrir pour que l’utilisateur renseigne
où se situe l’objet à récupérer (coordonnées, orientation et hauteur)
et s’il veut le plus court chemin (« Distance ») ou le chemin le
plus rapide (« Temps »), ou encore s’il veut simuler la réalité
avec tous les chariots en mouvement (« Réalité »).

Une fois que l’utilisateur a choisi quel objet aller récupérer, il valide sa
requête.

Dans le cas où il avait sélectionné « Distance » ou « Temps », le tracé du plus court
ou du plus rapide chemin va s’afficher dans l’entrepôt. Dans le cas de « Temps », le chariot
doit ensuite se rendre dans la zone de livraison (en colonne 1).

Dans le cas où il avait sélectionné « Réalité », on montre à l’écran les déplacements
successifs de chaque chariot présent dans l’entrepôt. Chaque objet a un objet à aller chercher
qu’il doit ensuite rapporter en zone de livraison.

En appuyant sur le bouton « Rafraîchir », le programme met à jour la position
du chariot dans l’entrepôt, c’est-à-dire qu’il l’enlève de sa position de départ pour
le mettre à sa position d’arrivée. Ce bouton est accessible après avoir sélectionné
« Distance » ou « Temps ».

En appuyant sur le bouton « Dynamique », le programme met à jour la position
du dernier chariot dans l’entrepôt en le déplacement dynamiquement : il met 1 seconde
pour aller tout droit, 4 secondes pour prendre un virage et 7 secondes s’il doit faire
demi-tour. En réalité, on divise chaque temps par 2 pour accélérer la visualisation.
Ce bouton est accessible après avoir sélectionné « Temps ».

En appuyant sur le bouton « Livraison », le programme déplace tous les chariots dans
la zone de livraison, orientés de telle façon à être prêts à aller chercher un nouvel objet.
Si on a plus de 25 chariots dans l’entrepôt, on supprime les chariots surnuméraires.

En appuyant sur le bouton « Livraison », le programme réaffiche la configuration de 
l’entrepôt avec les 15 chariots par défaut.

# Projet d’Intelligence Artificielle – Partie 2

**Percetron une couche**

Il s’agit ici de déterminer la droite qui sépare l’espèce A de l’espace B
après apprentissage avec un perceptron une couche.

**Perceptron multi-couches**

Il s’agit ici d’effectuer l’apprentissage d’un jeu de données, et d’afficher l’erreur 
entre l’apprentissage et les données réelles.

**Apprentissage**

Il s’agit ici de classer une liste de données en différentes catégories. Dans un premier temps,
l’apprentissage est supervisé, alors qu’il ne l’est pas dans le second temps.
