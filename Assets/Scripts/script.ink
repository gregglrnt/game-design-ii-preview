VAR hasKey = false
VAR room = ->SALON
VAR timerStart = false

Bah alors, t'es toujours pas à la soirée ? #speaker:you

* [Non] Je viens pas finalement #speaker:me
    T'es sérieux, là ? Tu vas pas passer ta première soirée à la maison tout seul #speaker:you
    ** [Oui] Laisse-moi tranquille :) #speaker:me
    -> ARRIVAL
    ** [Non] Bon allez, j'arrive #speaker:me
    -> ARRIVAL
* [J'avais oublié] Je suis sous la douche, j'arrive ! #speaker:me
    Comment tu fais pour écrire sous la douche ? #speaker:you #waiting:3
    T'inquiète je gère #speaker:me #waiting:2
    -> ARRIVAL

== ARRIVAL == 

Dépêche-toi y'a presque plus de bière #speaker:you #waiting:2
Attends, je viens d'entendre un bruit bizarre #speaker:me

\#RIP #speaker:you #waiting:5
Mec, je crois que y'a quelqu'un dans le jardin #speaker:me #waiting:3

~ timerStart = true

Barre-toi #speaker:you
* Je vais voir de plus près [\[Aller dans le bureau\]] #speaker:me
    -> BUREAU
* Allez, j'me casse [\[Aller dans la cuisine\]] #speaker:me
    -> CUISINE
    
== CUISINE ==
~ room = ->CUISINE
Je crois que j'ai entendu un bruit chelou dans le salon #speaker:me

J'ai appelé les flics #speaker:me

Je commence à flipper #speaker:me

- (actions)
* [Prendre un couteau] J'ai pris le couteau... #speaker:me
-> actions
* [Ouvrir la porte du garage] Je me tire d'ici adios #speaker:me
-> GARAGE
~ room = ->GARAGE
* J'ai l'impression qu'il me manque quelque chose... [\[Retourner dans le salon\]] #speaker:me
-> SALON
* Je regarde s'il y a quelque chose dans la poubelle #speaker:me
-> actions

-> DONE

== BUREAU == 
~ room = ->BUREAU
OK y'a vraiment un gars dans le jardin... #speaker:me

- (actions) 
{!Tfk ? | Et maintenant ?} #speaker:you
* [Fouiller le bureau] Je vais regarder dans le bureau #speaker:me 
    Y'a rien dans le bureau #waiting:5
    Tu t'attendais à quoi ? #speaker:you
        ** Je sais pas #speaker:me 
            -> actions
        ** Les clés du garage, peut-être ? #speaker:me
            Oh, bien vu, elles sont dans ma chambre #speaker:you
            -> actions
+ [Rester ici] {&Je suis dans le bureau | Toujours dans le bureau | Il est sympa ce bureau en vrai | Y'aurait pas les clés du garage ici ? }  #speaker:me
    -> actions
* [Retourner dans le salon] Je me tire d'ici #speaker:me
    -> SALON 


== SALON ==
~ room = ->SALON

* [Aller dans la cuisine] #speaker:me
    -> CUISINE.actions
* [Aller dans le bureau] #speaker:me
    -> BUREAU.actions
* [Monter les escaliers] Je me cache dans la chambre #speaker:me
    -> CHAMBRE 
* [Descendre les escaliers] J'arrive à la cave ! #spekaer: me
    -> CAVE
    
== CHAMBRE ==
~ room = "chambre"

- (actions)
* [Aller dans le salon] Je retourne dans le salon #speaker:me
-> SALON
* [Aller dans la salle de bains] Il y a pas quelque chose dans la salle de bains ? #speaker:me
-> SDB
* [Fouiller la chambre] J'ai trouvé les clés #speaker:me
~ hasKey = true
-> actions

== SDB ==
~ room = "salle_de_bain"

- (actions)
-> DONE

== GARAGE ==
~ room = "garage"

{ hasKey == false:
    PUTAIN MEC LA PORTE EST FERMÉE À CLÉ ! #speaker:me
    -> closed
- else:
    -> open
}

- (closed)
Merde la clé est dans ma chambre #speaker:me
Mec grâce à toi je vais me faire tuer #speaker:me

-> CUISINE.actions

- (open)

* [Prendre la voiture] Allez c'est bon je me tire d'ici #speaker:me 
-> WIN

* [Retourner dans le salon] Je crois que j'ai oublié quelque chose...  #speaker:me
-> SALON

== WIN == 
C'est bon, j'arrive à la soirée #speaker: me
-> END 

== LOSE ==  
-> END

== shutDownLights == 
Le courant vient de sauter dans l'appartement #speaker:me

T'es sérieux ? #speaker:you 
Va dans la cave, le disjoncteur est dans la cave

    * {room == -> SALON} D'accord, j'y vais #speaker:me
    -> CAVE
    * Je reste où je suis #speaker:me
    -> room
    * {room == -> SDB } J'y vais #speaker:me
    -> CHAMBRE
    * {room != -> SALON && room != -> SDB} J'y vais #speaker:me
    -> SALON
    
    
-> DONE 

== CAVE ==
~ room = "cave"
-> END


