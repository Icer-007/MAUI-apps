# Sandwich quiz

Cette application a été créée pour animer des soirées quiz organisées par l'équipe d'improvisation dont je fais partie.

Pensée pour être rapidement prise en main par la personne assurant la régie, les commandes sont restreintes et se veulent intuitives.

Dans le même ordre d'idées, pour simplifier la préparation des questionnaires (la première soirée était basée sur des powerpoints !), les fichiers contenant les questions des différentes manches sont de simples fichiers texte devant répondre à une norme basique.


## Interface générale

Au lancement, l'application se présente ainsi.

<img width="1224" height="673" alt="image" src="https://github.com/user-attachments/assets/27039e6d-cb8a-452c-8658-f7b9af2f88eb" />

## Commandes

Les différentes zones d'interaction sont réparties ainsi.

<img width="1217" height="651" alt="image" src="https://github.com/user-attachments/assets/9510609e-2ddd-4b6f-853e-cf2a39a0eedb" />

### Interface principale

Le cadre de l'application est de la couleur de l'équipe ayant la main : rouge ou jaune.
Si aucune équipe n'a la main, le cadre est de couleur violette.

En **T**, se trouve le chronomètre. Il n'est visible que lorsqu'il tourne ou que son démarrage est manuel (manches 1, 3 et 5).

Un double clic dans la zone **X**, en haut à gauche, lance le mode mirroir.

Un double clic **en dehors de toutes les autres commandes** permet de basculer en mode plein écran et d'en sortir.

### Scores

<img width="472" height="150" alt="image" src="https://github.com/user-attachments/assets/d0eb5d31-9e1f-436c-bf3f-f73638c73ac8" />

Équipe de gauche (rouge) :
- A1 : donner ou retirer la main
- B1 : ajouter des points
- C1 : retirer des points

Équipe de droite (jaune) :
- A2 : donner ou retirer la main
- B2 : ajouter des points
- C2 : retirer des points

Le nombre de points attribués (en ajout ou en retrait) par les boutons B1/B2 et C1/C2 correspond au nombres de ronds verts situés entre les zones **E** et **F**.

Nombre de points attribués :
- E : enlever un rond vert
- F : ajouter un rond vert

### Manches

<img width="211" height="139" alt="image" src="https://github.com/user-attachments/assets/b3b9dbff-e61b-4a7e-9067-c7490252a3f3" />

Démarrer une manche :
- M1 : ouvre la sélection de fichiers en lançant le jingle de la manche 1
- M2 : ouvre la sélection de fichiers en lançant le jingle de la manche 2
- M3 : ouvre la sélection de fichiers en lançant le jingle de la manche 3
- M4 : ouvre la sélection de fichiers en lançant le jingle de la manche 4
- M5 : affiche le nom de la manche finale en lançant son jingle

Si le fichier sélectionné dans la popup contient un autre type de manche, l'application le détecte et bascule dans le mode correspondant en jouant le jingle de la manche détectée.

À noter : l'utilisation de ces boutons n'est pas obligatoire, il est possible de directement glisser/déposer le fichier voulu dans l'application.

### Sons

<img width="271" height="99" alt="image" src="https://github.com/user-attachments/assets/279f9f92-a85c-4e52-a513-b4d0abc33779" />

Gestion des sons :
- S1 : bascule d'activation/désactivation des sons
- S2 : lancement du son "bonne réponse"
- S3 : lancement du son "mauvaise réponse"
- S4 : lancement du son "stop à la mauvaise foi"

### Thèmes / Questions

<img width="521" height="400" alt="image" src="https://github.com/user-attachments/assets/d6e1f03d-c1c9-4711-939b-592c75bc9f3d" />


Une fois la manche chargée, la zone **Q** affiche les thèmes et/ou questions.

Les flèches **G** et **D** permettent de passer respectivement à l'étape précédente et l'étape suivante **à l'intérieur de la même manche**.

Le logo **L** déclenche l'affichage de la bonne réponse d'un QCM seulement si au moins une réponse a été sélectionnée. Cette action stoppera également le chronomètre.

## Principes d'utilisation

Comme le (célèbre) jeu télévisé dont il s'inspire, ce quiz confronte deux équipes de 3 personnes (deux improvisateurs et une personne du public) et se déroule en 5 manches :
- Manche 1 : une série de QCM auxquels chaque équipe devra répondre à tour de rôle
- Manche 2 : une série de questions n'ayant que 2 réponses possibles (les 2 réponses peuvent être valables en même temps), seule l'équipe la plus rapide peut répondre
- Manche 3 : a tour de rôle, chaque équipe répond à un questionnaire à thème, 3 thèmes étant disponibles
- Manche 4 : une série de questions dont les réponses ont toutes un point commun. Pour chaque question, seule l'équipe la plus rapide peut répondre
- Manche 5 : "Le sandwich de la mort", l'équipe ayant marqué le plus de point dans les manches précédentes désigne un de ses joueurs (de préférence la personne du public !) qui devra répondre à une série de 10 questions simples MAIS uniquement après avoir entendu toutes les questions 


### Début d'une manche

<img width="182" height="184" alt="image" src="https://github.com/user-attachments/assets/0936bada-72ad-4f31-b451-08835870bcd0" />

Le clic sur un bouton des manches 1 à 4 ouvre une fenêtre permettant de sélectionner le fichier contenant les questions/thèmes à utiliser.

La manche 5 ne nécessite pas de fichier car le principe est de mémoriser les questions avant d'y répondre, elles ne doivent donc pas être affichées.

Lors du clic sur un bouton de lancement d'une manche, le jingle correspondant est joué.

Si le fichier sélectionné correspond à une autre manche, l'application se mettra dans le mode de la manche qu'elle a déterminée d'après le fichier et jouera le jingle correspondant.

Pour améliorer la fluidité et simplifier son maniement, l'application accepte un fichier de questionnaire en mode drag and drop : plutôt que de cliquer sur un des boutons de manche, il suffit de glisser-déposer le fichier de questionnaire dans l'application.
Là également, l'application se mettra dans le mode de la manche qu'elle a déterminée d'après le fichier et jouera le jingle correspondant.


### Chronomètre

<img width="66" height="77" alt="image" src="https://github.com/user-attachments/assets/376de0ea-6429-49d1-86b8-00c39cfcac05" />

Durant les manches où les équipes jouent à tour de rôle (manches 1, 3 et 5), un chronomètre apparait, indiquant que son déclenchement est manuel... il suffit de cliquer dessus.

Durant les manches de rapidité (manches 2 et 4), le chronomètre se déclenche dès que l'opérateur donne la main à une équipe.

L'opérateur peut à tout moment stopper le chronomètre en cliquant dessus. Si le chronomètre expire, un jingle signale que le temps est dépassé... et qu'il faut répondre.

À noter : durant les manches de rapidité (manches 2 et 4), l'arrêt du chronomètre retire à la main à l'équipe et vice versa.

Le temps du chronomètre varie selon le type de manche :
- individuelle (manches 1 et 3) : 20 secondes
- concurrente (manches 2 et 4) : 5 secondes
- finale (manche 5) : 60 secondes

### Donner la main

L'application n'est pas dépendante d'un système de buzzer.
Pour donner ou retirer la main à une équipe, il suffit de cliquer dans la zone au dessus de son score.

Lorsqu'aucune équipe n'a la main, la bordure de l'application est de couleur violette.

Lorsqu'une équipe prend la main, son score est entourée d'un cadre blanc et la bordure de l'application prend la couleur de cette équipe (rouge ou jaune).

<img width="300" height="176" alt="image" src="https://github.com/user-attachments/assets/2bd36a7f-dfa0-4b46-bcb9-c5f04fcbed48" />       <img width="300" height="176" alt="image" src="https://github.com/user-attachments/assets/01e86f19-9508-4588-a41a-7d0cad05097f" />

### Effets sonores

Un bouton permet d'activer ou désactiver tous les effets sonores. <img width="88" height="22" alt="image" src="https://github.com/user-attachments/assets/3965076a-2f45-4618-af2c-eb873d482879" />

Deux effets sonores sont automatiques : le chargement d'une manche et l'expiration du chronomètre.

Outre ces effets sonores automatiques, l'opérateur dispose de 3 boutons de "réactions" sonores :
- un bouton "bonne réponse", émettant un tintement positif <img width="19" height="18" alt="image" src="https://github.com/user-attachments/assets/829c8d05-51b8-4734-80dd-004896b93237" />
- un bouton "mauvaise réponse", émettant un buzzer négatif <img width="12" height="18" alt="image" src="https://github.com/user-attachments/assets/ff848609-ba34-4095-b2c2-f3a4758cc18e" />
- un bouton "mauvaise foi", jouant un air de pipeau médiéval <img width="16" height="16" alt="image" src="https://github.com/user-attachments/assets/62409aaa-861e-4362-8583-a396605ec022" /> (et oui, car les improvisateurs sont là pour jouer de mauvaise foi mais même les bonnes choses ont une fin)

À noter : durant la dernière manche, l'expiration du chronomètre déclenche un son de foule déçue tandis que l'arrêt du chronomètre par l'opérateur joue une ambiance de foule joyeuse.

### Gestion des scores

Le nombre de points attribués par bonne réponse est égal au nombre de petits ronds verts se trouvant sous la zone d'affichage des questions.
Un clic sur la droite de ces ronds verts augmente leur nombre de 1 alors qu'un clic sur la gauche de ces ronds verts diminue leur nombre de 1.
Il peut y avoir de 1 à 10 points par question.

<img width="608" height="125" alt="image" src="https://github.com/user-attachments/assets/0c99bfe3-cbfd-4f53-a121-b4e587ddfe3a" />

La gestion des scores est entièrement manuelle. Pour augmenter le score d'une équipe, il suffit de cliquer sur la moitié haute de ce score.
Pour diminuer le score d'une équipe, il suffit de cliquer sur la moitié basse de ce score. Le nombre de points ajoutés ou retirés sera égal au nombre de ronds verts sous la zone d'affichage des questions.

À noter : les scores d'équipes ne vont que de 0 à 25, la première équipe à 25 gagne le droit de tenter la manche 5.

### Raccourcis clavier

Les raccourcis clavier disponibles sont :
- flèche gauche (←) : donner la main à l'équipe de gauche (rouge) ou lui retirer si elle l'a déjà
- flèche droite (→) : donner la main à l'équipe de droite (jaune) ou lui retirer si elle l'a déjà
- touche "plus" du pavé numérique (+) : augmenter le nombre de points par bonne réponse (ronds verts sous la zone des questions)
- touche "moins" du pavé numérique (-) : diminuer le nombre de points par bonne réponse (ronds verts sous la zone des questions)
- flèche haut (↑) : ajouter des points à l'équipe qui a la main (équivalent au clic sur la partie haute de son score)
- flèche bas (↓) : retirer des points à l'équipe qui a la main (équivalent au clic sur la partie basse de son score)

### Mode mirroir

Un bouton discret se trouve en haut à gauche de l'interface principale, au dessus de l'arrondi de la bordure. Un double clic sur cette zone ouvre une nouvelle fenêtre qui est la copie de la fenêtre principale.

<img width="136" height="161" alt="image" src="https://github.com/user-attachments/assets/a9311036-245f-49ed-b8ef-7bda1c850921" />

Cela permet de projeter la fenêtre principale tandis que l'opérateur effectue toutes ses actions sur la fenêtre secondaire.
Ainsi, le public ne voit pas de souris à l'écran. Le public ne verra pas non plus le signalement des zones de clic au moment de leur survol.
