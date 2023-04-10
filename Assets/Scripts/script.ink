Bah alors, t'es toujours pas à la soirée ? #speaker:incoming

* [Non] Je viens pas finalement #speaker:outcoming
    T'es sérieux, là ? #speaker:incoming
    ** [Oui] Laisse-moi tranquille :) #speaker:outcoming
    -> ARRIVAL
    ** [Non] Bon allez, j'arrive #speaker:outcoming
    -> ARRIVAL
* [Oh, j'avais oublié] Je suis sous la douche, j'arrive ! #speaker:outcoming
    Comment tu fais pour écrire sous la douche ? #speaker:incoming #waiting:3
    T'inquiète je gère #speaker:outcoming #waiting:2
    -> ARRIVAL

== ARRIVAL == 

Dépêche-toi y'a presque plus de bière #speaker: incoming #waiting:2
Attends, je viens d'entendre un bruit bizarre #speaker:outcoming

\#RIP #speaker:incoming #waiting:5
Mec, je crois que y'a quelqu'un dans le jardin #speaker: outcoming #waiting:0

Barre-toi #speaker:incoming
* Je vais voir de plus près (Aller dans le bureau) #speaker:outcoming
    -> BUREAU
* Allez, j'me casse (Aller dans la cuisine) #speaker:outcoming
    -> CUISINE
    
== CUISINE ==
-> DONE

== BUREAU == 
-> DONE

-> DONE



