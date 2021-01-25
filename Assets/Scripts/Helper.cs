using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public enum emotionsCreateur
    {
        naturel,
        enerve,
        triste,
        espiegle,
        rire

    }
    public static void changerCreateurSprite(GameObject createur, emotionsCreateur emotion)
    {
        createur.GetComponent<DieuxComportement>().setSprite(emotion);
    }

    public static void addExpression(GameObject cible, Expression.nomsExpressions expression)
    {
        GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Vector3 position = new Vector3(cible.transform.position.x, cible.transform.position.y, cible.transform.position.z);
        Instantiate(GM.prefab, position, Quaternion.identity);
        changeExpression(cible, Expression.nomsExpressions.Sommeil);
    }

    public static void changeExpression(GameObject cible, Expression.nomsExpressions expression) 
    {
        Animator expression_animator = GameObject.FindObjectOfType<Animator>(); 
        Expression expression_gameobject= GameObject.FindObjectOfType<Expression>();
        expression_gameobject.changerExpression(Expression.nomsExpressions.Coeur);
    }

}
