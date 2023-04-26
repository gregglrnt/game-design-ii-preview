VAR good_address = false

Bonsoir, quelle est votre urgence ? #speaker:you

* Tout va bien #speaker:me
-> END
* Il se passe quelque chose d'étrange  #speaker:me
    Expliquez-moi ce qu'il se passe #speaker:you
    Je suis dans mon salon et j'entends quelqu'un rôder autour de la maison. #speaker:me
    Il est dans le jardin.
    Je crois qu'il a essayé d'ouvrir la porte.
    Attendez-vous quelqu'un en particulier? #speaker:you
    ** Non #speaker:me
    -> NON
    ** Oui #speaker:me
    -> OUI

== NON ==

Quelle est votre adresse ? #speaker:you
* 34 Rue Alder #speaker:me
- Vous pouvez confirmer ? #speaker:you
* 34 Rue Adler #speaker:me
* 43 Rue Aldre #speaker:me
* 34 Rue Alder #speaker:me
~ good_address = true

- Bien noté. Nous vous envoyons une patrouille. Veuillez rester en ligne. #speaker:you

Auriez-vous un moyen de sortir de chez vous en toute sécurité ?

* J'ai ma voiture dans le garage... #speaker:me
* Je peux vérifier si la porte d'entrée est dégagée  #speaker: me
-> END

- Coucou

-> KILLER_INSIDE

== OUI == 

J'attends mon coloc, mais je crois qu'il est en soirée et qu'il doit rentrer plus tard. #speaker:me

Quelle est votre adresse ? #speaker:you
* 34 Rue Alder #speaker:me
- Vous pouvez confirmer ? #speaker:you
* 34 Rue Adler #speaker:me
* 43 Rue Aldre #speaker:me
* 34 Rue Alder #speaker:me
~ good_address = true

- -> KILLER_INSIDE

-> KILLER_INSIDE

== KILLER_INSIDE ==
Oh merde je crois qu'il est rentré #speaker:me

Enfermez-vous dans une pièce et attendez l'intervention des forces de l'ordre. #speaker:you

* OK #speaker:me
* Je vais plutôt essayer de sortir.  #speaker:me


- Les forces de l'ordre sont devant votre domicile.  #speaker:you

{good_address: 
     Je vous vois. #speaker:me
     -> END
- else : 
    Je vous vois pas, vous êtes sûr que vous avez la bonne adresse ? #speaker:me
-> WRONG_ADDRESS
    
}

== WRONG_ADDRESS
Vous pouvez nous redonner l'addresse ? 
* 34 Rue Adler #speaker:me
* 43 Rue Aldre #speaker:me
* 34 Rue Alder #speaker:me
~ good_address = true
- Très bien, nous allons intervenir #speaker:you





-> END