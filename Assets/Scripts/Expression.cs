using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expression : MonoBehaviour
{

    public enum nomsExpressions
    {
        Ampoule,
        Brouillon,
        Coeur, 
        Colere, 
        Exclamation, 
        GoutteSueur,
        NoteMusique, 
        Question,
        Sommeil,
        Blanc
    }

    [SerializeField] private nomsExpressions expressions; 

    public void changerExpression(nomsExpressions expression)
    {
        switch(expression)
        {
            case nomsExpressions.Coeur:
                GetComponent<Animator>().SetInteger("Expression", 4);
            break; 
        }
    }

    private void Update() 
    {
        if(GetComponent<Animator>().GetBool("Destroy"))
        {
            Destroy(gameObject);
        }
    }
}
