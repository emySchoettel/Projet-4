using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    public static bool bulle_bool = false; 

    public enum sol
    {
        terre
    }
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


    #region Attributs
    public enum mondes
    {
        hub, 
        monde1, 
        monde2,
        monde3, 
        monde4,
        tout
    }
    
    public enum typeAttribut
    {
        ChaineDeCaractere, 
        autre, 
        TOR, 
        integer,
        none
    }


    #endregion

    #region Attributs Player

    public static void addAttributPlayer(Attribut att)
    {
        Helper.getPlayer().GetComponent<PlayerController>().GetAttributs().Add(att);
    }

    #endregion

    public static void playTexte(DialogueTest.DialogueSaisie dialogue)
    {
        DialogueManager dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
        dialogueManager.speaker.text = dialogue.parleur.ToString();
        
        dialogueManager.getCanvas().SetActive(true);

    }

    public static GameObject addExpression(GameObject cible, Expression.nomsExpressions expression)
    {
        bulle_bool = true; 
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
            Debug.Log(EmplacementBulle.name);
            if(EmplacementBulle != null)
            {
                Vector3 position = new Vector3(EmplacementBulle.transform.position.x, EmplacementBulle.transform.position.y, EmplacementBulle.transform.position.z);
                bulle = Instantiate(GM.prefab, position, Quaternion.identity);
                bulle.transform.parent = cible.transform;
                changeExpression(cible, expression);
            }
        }
        Debug.Log(bulle.name);
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

    public static void ChangeDirection(GameObject personnage, Helper.directions unedirection)
    {
        Animator anim = personnage.GetComponent<Animator>();

        if(anim != null)
        {
            if(personnage.CompareTag("Player"))
            {
                anim.SetBool("IDLELeft", false);
                anim.SetBool("IDLERight", false);
                anim.SetBool("IDLEUp", false);
                anim.SetBool("IDLEDown", false);
                switch(unedirection)
                {
                    case directions.bas:
                        anim.SetBool("IDLEDown", true);
                        anim.SetBool("WalkDown", false);
                        anim.SetBool("IDLELeft", false);
                        anim.SetBool("IDLERight", false);
                        anim.SetBool("IDLEUp", false);
                    break; 

                    case directions.gauche:
                        anim.SetBool("IDLELeft", true);
                        anim.SetBool("WalkLeft", false);
                        anim.SetBool("IDLERight", false);
                        anim.SetBool("IDLEUp", false);
                        anim.SetBool("IDLEDown", false);
                    break; 

                    case directions.droite:
                        anim.SetBool("IDLERight", true);
                        anim.SetBool("WalkRight", false);
                        anim.SetBool("IDLELeft", false);
                        anim.SetBool("IDLEUp", false);
                        anim.SetBool("IDLEDown", false);
                    break; 

                    case directions.haut:
                        anim.SetBool("IDLEUp", true);
                        anim.SetBool("WalkUp", false);
                        anim.SetBool("IDLERight", false);
                        anim.SetBool("IDLELeft", false);
                        anim.SetBool("IDLEDown", false);
                    break; 
                }
            }
            else
            {
                anim.SetBool("up", false);
                anim.SetBool("down", false);
                anim.SetBool("left", false);
                anim.SetBool("right", false);
                switch(unedirection)
                {
                    case directions.droite:
                    anim.SetBool("idleleft", true);
                    break;

                    case directions.gauche:
                    anim.SetBool("idleright", true);
                    break;

                    case directions.bas:
                    anim.SetBool("idleup", true);
                    break;

                    case directions.haut:
                    anim.SetBool("idledown", true);
                    break;
                
                } 
            }
        }
    }

    public static GameObject getPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }
}
