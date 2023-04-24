VAR hasKey = false
VAR room = ->SALON
VAR timerStart = false
VAR lights = true
VAR hasCarKey = false

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
+ [Ouvrir la porte du garage] Je me tire d'ici adios #speaker:me
-> GARAGE
~ room = ->GARAGE
+ J'ai l'impression qu'il me manque quelque chose... [\[Retourner dans le salon\]] #speaker:me
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
    J'ai trouvé les clés de la voiture #speaker:me 
    ~ hasCarKey = true
    Ah oui, c'est vrai, j'avais oublié qu'elles étaient là #speaker:you 
    -> actions
+ [Rester ici] {&Je suis dans le bureau | Toujours dans le bureau | Il est sympa ce bureau en vrai | Y'aurait pas les clés du garage ici ? }  #speaker:me
    -> actions
+ [Retourner dans le salon] Je me tire d'ici #speaker:me
    -> SALON 


== SALON ==
~ room = ->SALON

+ [Aller dans la cuisine] #speaker:me
    -> CUISINE.actions
+ [Aller dans le bureau] #speaker:me
    -> BUREAU.actions
+ [Monter les escaliers] Je me cache dans la chambre #speaker:me
    -> CHAMBRE 
+ [Descendre les escaliers] J'arrive à la cave ! #spekaer: me
    -> CAVE
    
== CHAMBRE ==
~ room = ->CHAMBRE

- (actions)
* [Aller dans le salon] Je retourne dans le salon #speaker:me
-> SALON
* [Fouiller la chambre] J'ai trouvé les clés #speaker:me
~ hasKey = true
-> actions


== GARAGE ==
~ room = ->GARAGE

{ hasKey == false:
    PUTAIN MEC LA PORTE EST FERMÉE À CLÉ ! #speaker:me
    -> closed
- else:
    -> open
}

- (closed)
Merde la clé est dans ma chambre #speaker:me
Mec à cause de toi je vais me faire tuer #speaker:me
Je retourne dans la cuisine

-> CUISINE.actions

- (open)

* { hasCarKey == true} [Prendre la voiture] Allez c'est bon je me tire d'ici #speaker:me 
-> WIN

+ {hasCarKey == false} [La voiture est fermée à clé] Elles sont où les clés de la voiture ? #speaker:me
-> open

+ [Retourner dans le salon] Je crois que j'ai oublié quelque chose...  #speaker:me
-> SALON

== WIN == 
C'est bon, j'arrive à la soirée #speaker: me
-> END 

== LOSE ==  
-> END

== shutDownLights == 
~ lights = false
Le courant vient de sauter dans l'appartement #speaker:me

T'es sérieux ? #speaker:you 
Le disjoncteur est dans la cave

    * {room == -> SALON} D'accord, j'y vais #speaker:me
    -> CAVE
    * Je reste où je suis #speaker:me
    -> room
    * {room != -> SALON} J'y vais #speaker:me
    -> SALON
    
    
-> DONE 

== CAVE ==
~ room = ->CAVE

- (actions)
    * {lights == false} J'ai trouvé le disjoncteur
        ~ lights = true
        -> actions
    + Je reste ici 
        -> actions
    * Il n'y a rien ici, je retourne dans le salon 
        -> SALON


        





-> END


