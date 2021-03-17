using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    public enum speakers
    {
        None,
        Joueur,
        Pierre, 
        Solabis, 
        Lunabis,
        Jack,
        Flow, 
        Marie, 
        Lucas, 
        Legardedelaville, 
        Lapetitefille,
        Lepecheur,
        Jo
    }

    public enum directions{
        droite,
        gauche,
        haut,
        bas
    }


    public static GameObject addExpression(GameObject cible, Expression.nomsExpressions expression)
    {
        GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GameObject bulle = null; 
        GameObject EmplacementBulle = null; 
        if(GM != null)
        {
            for (int i = 0; i < cible.transform.childCount; i++)
            {
                if(cible.transform.GetChild(i).CompareTag("BulleTarget"))
                {   
                    EmplacementBulle = cible.transform.GetChild(i).gameObject;
                }
            }
        if(EmplacementBulle != null)
        {
            Vector3 position = new Vector3(EmplacementBulle.transform.position.x, EmplacementBulle.transform.position.y, EmplacementBulle.transform.position.z);
            bulle = Instantiate(GM.prefab, position, Quaternion.identity);
            bulle.transform.parent = cible.transform;
            changeExpression(cible, expression);
            }
        }
        return bulle;
    }

    private static void changeExpression(GameObject cible, Expression.nomsExpressions expression) 
    {
        Animator expression_animator = GameObject.FindObjectOfType<Animator>(); 
        Expression expression_gameobject= GameObject.FindObjectOfType<Expression>();
        expression_gameobject.changerExpression(expression);
    }

    public void Fading(bool fade, GameObject panelGM)
    {
        StartCoroutine(Fade(fade, panelGM));
    }

    public IEnumerator Fade(bool fade, GameObject panelGM) 
    {
        Image img = panelGM.GetComponent<Image>();

        if (!fade)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            //isFade = true;
            // loop over 1 second
            for (float i = 0; i <= 255; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }
}
