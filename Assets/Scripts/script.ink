VAR hasKey = false

Bah alors, t'es toujours pas à la soirée ? #speaker:incoming

* [Non] Je viens pas finalement #speaker:outcoming
    T'es sérieux, là ? Tu vas pas passer ta première soirée à la maison tout seul #speaker:incoming
    ** [Oui] Laisse-moi tranquille :) #speaker:outcoming
    -> ARRIVAL
    ** [Non] Bon allez, j'arrive #speaker:outcoming
    -> ARRIVAL
* [J'avais oublié] Je suis sous la douche, j'arrive ! #speaker:outcoming
    Comment tu fais pour écrire sous la douche ? #speaker:incoming #waiting:3
    T'inquiète je gère #speaker:outcoming #waiting:2
    -> ARRIVAL

== ARRIVAL == 

Dépêche-toi y'a presque plus de bière #speaker:incoming #waiting:2
Attends, je viens d'entendre un bruit bizarre #speaker:outcoming

\#RIP #speaker:incoming #waiting:5
Mec, je crois que y'a quelqu'un dans le jardin #speaker:outcoming #waiting:3

Barre-toi #speaker:incoming
* Je vais voir de plus près [Aller dans le bureau] #speaker:outcoming
    -> BUREAU
* Allez, j'me casse [Aller dans la cuisine] #speaker:outcoming
    -> CUISINE
    
== CUISINE ==
Je crois que j'ai entendu un bruit chelou dans le salon #speaker:incoming

J'ai appelé les flics #speaker:outcoming

Je commence à flipper grave #speaker:incoming
-> cuisine_actions

== cuisine_actions
* [Prendre un couteau] J'ai pris le couteau... -> cuisine_actions
* [Ouvrir la porte du garage] Je me tire d'ici adios -> GARAGE
* J'ai l'impression qu'il me manque quelque chose... [Retourner dans le salon] -> SALON

-> DONE

== BUREAU == 
OK y'a vraiment un gars dans le jardin... #speaker:incoming
-> bureau_actions

== bureau_actions == 
Je fais quoi ? 
* [Fouiller le bureau] Y'a rien dans le bureau #waiting:10
    Tu t'attendais à quoi ? #speaker:incoming
        ** Je sais pas #speaker:outcoming 
            -> bureau_actions 
        ** Les clés du garage, peut-être ? #speaker:outcoming
            Oh, bien vu, elles sont dans ma chambre #speaker:incoming
            -> bureau_actions
+ [Rester ici] {Je suis dans le bureau|...}  #speaker:incoming
    -> bureau_actions
* [Retourner dans le salon] Je me tire d'ici -> SALON


== SALON ==
-> DONE


== GARAGE ==
{ hasKey == false:
    PUTAIN MEC LA PORTE EST FERMÉE À CLEF ! #speaker:incoming
    -> garage_closed
- else:
    -> garage_open
}

== garage_closed
Merde la clef est dans ma chambre #speaker:outcoming
Mec grâce à toi je vais me faire tuer #speaker:incoming

-> cuisine_actions

== garage_open

* Allez c'est bon je me tire d'ici [Prendre la voiture] #speaker:incoming 
-> WIN

* Je crois que j'ai oublié quelque chose... [Retourner dans le salon] #speaker:outcoming
-> LOSE

== WIN == 
-> DONE 
== LOSE ==  
-> DONE



