using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expression : MonoBehaviour
{
    private bool finished = false; 

    private Animator animator; 
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

    private void Awake() 
    {
        animator = GetComponent<Animator>(); 
    }

    public void changerExpression(nomsExpressions expression)
    {          
        switch(expression)
        {
            case nomsExpressions.Exclamation:
                animator.SetInteger("Expression", 1);
            break; 
            case nomsExpressions.Question:
                animator.SetInteger("Expression", 2);
            break;  
            case nomsExpressions.NoteMusique:
                animator.SetInteger("Expression", 3);
            break; 
            case nomsExpressions.Coeur:
                animator.SetInteger("Expression", 4);
            break;  
            case nomsExpressions.Colere:
                animator.SetInteger("Expression", 5);
            break; 
            case nomsExpressions.GoutteSueur:
                animator.SetInteger("Expression", 6);
            break; 
            case nomsExpressions.Brouillon:
                animator.SetInteger("Expression", 7);
            break; 
            case nomsExpressions.Blanc:
                animator.SetInteger("Expression", 8);
            break; 
            case nomsExpressions.Ampoule:
                animator.SetInteger("Expression", 9);
            break; 
            case nomsExpressions.Sommeil:
                animator.SetInteger("Expression", 10);
            break;  
        }
    }

    private void Update() 
    {
        if(animator.GetBool("Destroy"))
        {
            animator.SetInteger("Expression", 0);
            Destroy(gameObject);
        }
    }
}
