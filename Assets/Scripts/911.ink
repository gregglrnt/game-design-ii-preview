VAR good_address = false

Bonsoir, quelle est votre urgence ? #player:you

* Tout va bien #player:me
-> END
* Il se passe quelque chose d'étrange  #player:me
    Expliquez-moi ce qu'il se passe #player:you
    Je suis dans mon salon et j'entends quelqu'un rôder autour de la maison. #player:me
    Il est dans le jardin.
    Je crois qu'il a essayé d'ouvrir la porte.
    Attendez-vous quelqu'un en particulier? #player:you
    ** Non #player:me
    -> NON
    ** Oui #player:me
    -> OUI

== NON ==

Quelle est votre adresse ? #player:you
* 34 Rue Alder #player:me
- Vous pouvez confirmer ? #player:you
* 34 Rue Adler #player:me
* 43 Rue Aldre #player:me
* 34 Rue Alder #player:me
~ good_address = true

- Bien noté. Nous vous envoyons une patrouille. Veuillez rester en ligne. #player:you

Auriez-vous un moyen de sortir de chez vous en toute sécurité ?

* J'ai ma voiture dans le garage... #player:me  #player:me
* Je peux vérifier si la porte d'entrée est dégagée  #player:me
-> END

- Coucou

-> KILLER_INSIDE

== OUI == 

J'attends mon coloc, mais je crois qu'il est en soirée et qu'il doit rentrer plus tard. #player:me

Quelle est votre adresse ? #player:you
* 34 Rue Alder #player:me
- Vous pouvez confirmer ? #player:you
* 34 Rue Adler #player:me
* 43 Rue Aldre #player:me
* 34 Rue Alder #player:me
~ good_address = true

- -> KILLER_INSIDE

-> KILLER_INSIDE

== KILLER_INSIDE ==
Oh merde je crois qu'il est rentré #player:me

Enfermez-vous dans une pièce et attendez l'intervention des forces de l'ordre. #player:you

* OK #player:me
* Je vais plutôt essayer de sortir.  #player:me


- Les forces de l'ordre sont devant votre domicile.  #player:you

{good_address: 
     Je vous vois. #player:me
     -> END
- else : 
    Je vous vois pas, vous êtes sûr que vous avez la bonne adresse ? #player:me
-> WRONG_ADDRESS
    
}

== WRONG_ADDRESS
Vous pouvez nous redonner l'addresse ? 
* 34 Rue Adler #player:me
* 43 Rue Aldre #player:me
* 34 Rue Alder #player:me
~ good_address = true
- Très bien, nous allons intervenir #player:you





-> END