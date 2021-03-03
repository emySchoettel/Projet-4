using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public enum speakers
    {
        None,
        Joueur,
        Pierre, 
        Solabis, 
        Lunabis,
        Flow, 
        Marie, 
        Lucas, 
        Legardedelaville, 
        Lapetitefille,
        Lepecheur,
        Jo
    }

    // public static void changerCreateurSprite(GameObject createur, emotionsCreateur emotion)
    // {
    //     //createur.GetComponent<DieuxComportement>().setSprite(emotion);
    //     foreach(Sprite sp in createur.GetComponent<DieuxComportement>().sprites)
    //     {
    //         Debug.Log(sp.name);
    //     }
    // }

    public static GameObject addExpression(GameObject cible, Expression.nomsExpressions expression)
    {
        GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject bulle = null; 
        if(GM != null)
        {
            Vector3 position = new Vector3(cible.transform.position.x, cible.transform.position.y, cible.transform.position.z);
            bulle = Instantiate(GM.prefab, position, Quaternion.identity);
            bulle.transform.parent = GameObject.Find("Player").transform;
            changeExpression(cible, expression);
        }
        return bulle;
    }

    private static void changeExpression(GameObject cible, Expression.nomsExpressions expression) 
    {
        Animator expression_animator = GameObject.FindObjectOfType<Animator>(); 
        Expression expression_gameobject= GameObject.FindObjectOfType<Expression>();
        expression_gameobject.changerExpression(expression);
    }
}
