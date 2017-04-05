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

Une fenêtre va donc
s’ouvrir pour savoir où l’objet se situe (coordonnées, orientation et hauteur)
et s’il veut le plus court chemin en terme de distance ou de temps.

Une fois que l’utilisateur a choisi quel objet aller récupérer, il valide sa
requête. La fenêtre se ferme alors et le tracé du plus court chemin va alors
s’afficher dans l’entrepôt.

En appuyant sur le bouton « Rafraîchir », le programme met à jour la position
du chariot dans l’entrepôt, c’est-à-dire l’enlever de sa position de départ pour
le mettre à sa position d’arrivée.

En appuyant sur le bouton « Dynamique », le programme met à jour la position
du dernier chariot dans l’entrepôt en le déplacement dynamiquement : il met 1 seconde
pour aller tout droit, 3 secondes pour prendre un virage et 6 secondes s’il doit faire
demi-tour.

# Projet d’Intelligence Artificielle – Partie 2

**Percetron une couche**

**Perceptron multi-couches**

**Apprentissage**

Il s’agit ici de classer une liste de données en 2 catégories. Dans un premier temps,
l’apprentissage est supervisé, alors qu’il ne l’est pas dans le second temps.
