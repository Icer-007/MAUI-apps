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

Le logo **L** déclenche l'affichage de la bonne réponse d'un QCM seulement si au moins une réponse a été sélectionnée. Il sert également dans la manche 5, pour signifier que la manche est victorieuse.
Dans ces deux cas, un clic sur le logo **L** stoppera également le chronomètre.

## Principes d'utilisation

Comme le (célèbre) jeu télévisé dont il s'inspire, ce quiz confronte deux équipes de 3 personnes (deux improvisateurs et une personne du public) et se déroule en 5 manches :
- Manche 1 : une série de QCM auxquels chaque équipe devra répondre à tour de rôle
- Manche 2 : une série de questions n'ayant que 2 réponses possibles (les 2 réponses peuvent être valables en même temps), seule l'équipe la plus rapide peut répondre
- Manche 3 : à tour de rôle, chaque équipe répond à un questionnaire à thème, 3 thèmes étant disponibles
- Manche 4 : une série de questions dont les réponses ont toutes un point commun. Pour chaque question, seule l'équipe la plus rapide peut répondre
- Manche 5 : "Le sandwich de la mort", l'équipe ayant marqué le plus de point dans les manches précédentes désigne un de ses joueurs (de préférence la personne du public !) qui devra répondre à une série de 10 questions simples MAIS uniquement après avoir entendu toutes les questions 


### Début d'une manche

<img width="182" height="184" alt="image" src="https://github.com/user-attachments/assets/0936bada-72ad-4f31-b451-08835870bcd0" />

Le clic sur un bouton des manches 1 à 4 ouvre une fenêtre permettant de sélectionner le fichier contenant les questions/thèmes à utiliser.

La manche 5 ne nécessite pas de fichier car le principe est de mémoriser les questions avant d'y répondre, elles ne doivent donc pas être affichées.

Lors du clic sur un bouton de lancement d'une manche, le jingle correspondant est joué.

Si le fichier choisi dans la popup correspond à une autre manche, l'application se mettra dans le mode de la manche qu'elle a déterminée d'après le fichier et jouera le jingle correspondant.

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

À noter : durant la dernière manche, l'expiration du chronomètre déclenche un son de foule déçue tandis qu'un clic sur le logo **L** arrête le chronomètre et déclenche un son de foule joyeuse.

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
- touche flèche gauche (←) : donner la main à l'équipe de gauche (rouge) ou lui retirer si elle l'a déjà
- touche flèche droite (→) : donner la main à l'équipe de droite (jaune) ou lui retirer si elle l'a déjà
- touche "plus" du pavé numérique (+) : augmenter le nombre de points par bonne réponse (ronds verts sous la zone des questions)
- touche "moins" du pavé numérique (-) : diminuer le nombre de points par bonne réponse (ronds verts sous la zone des questions)
- touche flèche haut (↑) : ajouter des points à l'équipe qui a la main (équivalent au clic sur la partie haute de son score)
- touche flèche bas (↓) : retirer des points à l'équipe qui a la main (équivalent au clic sur la partie basse de son score)

### Mode mirroir

Un bouton discret se trouve en haut à gauche de l'interface principale, au dessus de l'arrondi de la bordure. Un double clic sur cette zone ouvre une nouvelle fenêtre qui est la copie de la fenêtre principale.

<img width="179" height="149" alt="image" src="https://github.com/user-attachments/assets/0f43091c-4488-403d-a8fa-d73576d8e30d" />

Cela permet de projeter la fenêtre principale tandis que l'opérateur effectue toutes ses actions sur la fenêtre secondaire.
Ainsi, le public ne voit pas de souris à l'écran. Le public ne verra pas non plus le signalement des zones de clic au moment de leur survol.

## Ergonomies des différentes manches

Le nombre de points attribués par bonne réponse est à spécifier au début de chaque manche et se règle en affichantle bon nombre de ronds verts à l'aides des zones **E** et **F**.

Dans les manches concurrentes (manches 2 et 4), si l'équipe qui a pris la main donne une mauvaise réponse, l'autre équipe récupère les points de la question.

Dans les manches non concurrentes (manches 1 et 3), l'équipe qui a la main ne perd pas de point sur une mauvaise réponse
(et l'équipe qui n'a pas la main ne marque pas de point).

### Manche 1 : QCM

Après chargement du fichier, la première question s'affiche. L'opérateur peut alors cliquer sur la flèche droite **D** pour afficher une à une les réponses possibles.

Lorsque toutes les propositions de réponse sont affichées, le chronomètre apparaît, prêt à être lancé.

Par un clic sur une proposition de réponse, l'opérateur peut la sélectionner/déselectionner à la demande des candidats. Les réponses sélectionnées s'affichent en bleu.

Dès qu'au moins une réponse est sélectionnée, un clic sur le logo **L** permet d'afficher la bonne réponse, celle-ci s'affichera à ce moment en vert. L'affichage de la bonne réponse stoppe également le chronomètre.

Une fois la bonne réponse révélée, la flèche droite **D** redevient accessible pour afficher la question suivante. Si ce n'est pas le cas, cela signifie que l'on est à la fin du questionnaire.

Si la question affichée n'est la première de la manche, la flèche gauche **G** permet à tout moment de revenir à la question précédente.

### Manche 2 : 2 réponses possibles... ou les 2

Après chargement du fichier, le nom de la manche s'affiche, ainsi que son thème.

Le thème présente les 2 réponses possibles. Exemple : *"À gauche, à droite ou les deux"*

Dans cette manche, la seule action de l'opérateur est de donner la main à l'équipe qui se sera manifestée le plus vite pour répondre. Ce qui déclenchera le chronomètre.

Rappel : le chronomètre s'arrête quand on retire la main à une équipe et une équipe perd la main quand le chronomètre s'arrête.

### Manche 3 : Questionnaires à thème

Après chargement du fichier, le nom de la manche s'affiche. L'opérateur peut alors cliquer sur la flèche droite **D** pour afficher un à un les thèmes proposés.

Lorsque toutes les thèmes sont affichés et qu'un (et un seul) thème a été sélectionné par un clic, la flèche droite **D** redevient accessible pour afficher la première question du thème choisi.
Le chronomètre apparaît alors, prêt à être lancé.

Une fois le thème lancé, le rôle de la flèche droite **D** est d'afficher la question suivante, ce qui stoppe également le chronomètre.
Si un clic sur la flèche droite **D** affiche un écran vide, cela signifie qu'il n'y a plus de questions pour ce thème et qu'un nouveau clic ramènera à la liste des thèmes pour que la seconde équipe puisse jouer.

Une fois le thème lancé, le rôle de la flèche gauche **G** est de revenir à la question précédente, ce qui stoppe également le chronomètre.
Si la question affichée est la première de son thème, l'écran passera à la liste des thèmes.

### Manche 4 : Réponses conditionnées

Après chargement du fichier, le nom de la manche s'affiche, ainsi que son thème.

Le thème présente la condition pour qu'une réponse soit acceptée. Exemple : *"La réponse est forcément un pays"* implique que, pour toutes les questions posées, la réponse doit être un nom de pays.
Là encore, les improvisateurs peuvent faire preuve de mauvaise foi en inventant un nom plausible de pays.
S'ils sont convaincants, ils peuvent emporter le point, sinon, le bouton *"mauvaise foi"* **S4** peut servir à couper court.

Dans cette manche, la seule action de l'opérateur est de donner la main à l'équipe qui se sera manifestée le plus vite pour répondre. Ce qui déclenchera le chronomètre.

Rappel : le chronomètre s'arrête quand on retire la main à une équipe et une équipe perd la main quand le chronomètre s'arrête.


### Manche 5 : La finale

Après un clic sur le bouton **M5**, le nom de la manche "*Le sandwich de la mort*" s'affiche, ainsi que le chronomètre.


Le joueur participant (de préférence la personne du public !) devra répondre à une série de 10 questions simples MAIS uniquement après avoir entendu toutes les questions.

Dans cette manche, l'opérateur se doit de déclencher le chronomètre une fois que le candidat a entendu les 10 questions.

Si le candidat a pu répondre aux questions posées, dans l'ordre et avant l'expiration du chronomètre, l'opérateur clique sur le logo **L** afin de stopper le chronomètre et déclencher le jingle de victoire de la manche 5.

Si le chronomètre expire, cela déclenchera le jingle de défaite de la manche 5.


## Format des fichiers de questionnaires

Les exemples de fichiers donnés ci-dessous sont dans le répertoire "*SandwichQuizzSln/Samples of round files*".

### Manche 1

Le fichier doit être constitué de blocs contenant une question et ses réponses. Une (ou plusieurs) ligne vide représente une séparation de bloc.

La première ligne d'un bloc contient la question, elle sera affichée telle quelle à l'écran.

Toutes les lignes suivantes d'un bloc représentent les propositions de réponse, à raison d'une réponse par ligne.
Pour faciliter la rédaction, une réponse peut commencer par un symbole *"-"* (qui ne sera pas affiché à l'écran).

Pour être identifiée comme bonne réponse, une ligne doit commencer par le sybole *"->"* (qui ne sera, bien sûr, pas affiché à l'écran).

exemple de fichier de manche 1 :
```
Question 1 ?
-mauvaise réponse 1
-mauvaise réponse 2
->bonne réponse 1
-mauvaise réponse 3

Question 2 ?
-mauvaise réponse 1
->bonne réponse 1
-mauvaise réponse 2



Question 3 ?
mauvaise réponse 1
-mauvaise réponse 2
mauvaise réponse 3
->bonne réponse 1


Question 4 ?
->bonne réponse 1
-mauvaise réponse 1
->bonne réponse 2
-mauvaise réponse 2


Question 5 ?
->bonne réponse 1
->bonne réponse 2
->bonne réponse 3
->bonne réponse 4
```

Remarque : Si le fichier ne contient **qu'un seul bloc** *"questions et ses réponses"*, il sera identifié comme un fichier (en format alternatif) de manche 3.

### Manche 2

Le fichier doit être constitué de 2 lignes, séparées par une (ou plusieurs) ligne vide.

La première ligne contient le titre de la manche, la seconde contient le thème. Elle seront affichées telle quelle à l'écran.

**Attention** : Pour être identifié comme un fichier de manche 2, la première ligne (titre de la manche) doit contenir le texte *" ou "*, **avec les espaces** (que ce soit en majuscules ou en minuscules)

exemple de fichier de manche 2 :
```
L'un ou l'autre... ou les deux

Shakespeare, Britney Spears ou les deux
```
autre exemple de fichier de manche 2 :
```
Un choix ou pas

En haut, en bas
```
### Manche 3

La première ligne du fichier contient le nom de la manche (qui sera affiché tel quel), suivie d'une ligne vide (ou plusieurs).

Suivent les différents questionnaires, sous forme de blocs séparés par une ligne vide (ou plusieurs).

Chaque bloc comporte, en première ligne, un thème (qui sera affiché tel quel). Le reste du bloc est composé des questions de ce thème, à raison d'une question par ligne.
Pour faciliter la rédaction, une question peut commencer par un symbole "-" (qui ne sera pas affiché à l'écran).

exemple de fichier de manche 3 :
```
Voici les thèmes

Thème - premier sujet
question 1 ?
ici la question 2

Thème - autre sujet
question ici
-question dont on ne verra pas le premier tiret
est ce tout ?

Thème - Thème 4
-pourqui pas de 3 ?
tiret ou pas ?
-et c'est tout
```

Il existe un format alternatif, pour jouer sans afficher les questions des thèmes (comme dans la version télévisée), où seuls les thèmes sont présents dans le fichier.
Il ne doit y avoir dans ce cas qu'un seul bloc dans le fichier, sinon il pourrait être identifié comme un fichier de manche 1.

Dans ce format alternatif, pour faciliter la rédaction, un thème peut commencer par un symbole "-" (qui ne sera pas affiché à l'écran).

exemple de fichier alternatif de manche 3 :
```
Voici les thèmes
-Thème - premier sujet
-Thème - autre sujet
Thème - Thème 4
```

### Manche 4


Le fichier doit être constitué de 2 lignes, séparées par une (ou plusieurs) ligne vide.

La première ligne contient le titre de la manche, la seconde contient le thème. Elle seront affichées telle quelle à l'écran.

**Attention** : si la première ligne (titre de la manche) contient le texte *" ou "*, **avec les espaces** (que ce soit en majuscules ou en minuscules),
le fichier sera identifié comme étant un fichier de manche 2.


exemple de fichier de manche 4 :
```
Condition de réponse

La réponse est forcément un pays
```
autre exemple de fichier de manche 4 :
```
Manche 4

Il faut répondre en argot
```


### Manche 5

Étant basée sur la mémoire du participant, la manche 5 ne nécessite aucun fichier de questionnaire.
