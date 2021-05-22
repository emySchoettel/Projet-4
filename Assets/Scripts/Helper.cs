using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{

    #region enum

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

    #region parameters
    public static bool bulle_bool = false; 

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

        getCanvasScript().changeCanvas(CanvasManager.canvas.dialogue);
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

    public static CanvasManager getCanvasScript()
    {
        return GameObject.FindObjectOfType<CanvasManager>();
    }

    public static GameObject getCanvasGO()
    {
        return GameObject.Find("Canvas");
    }

    #region ui_attribut

    public static void manageAttributUIjoueur(GameObject att)
    {
        //ajouter l'inventaire à l'écran 
        AttributManager attManager = GameObject.FindObjectOfType<AttributManager>();
        List<Attribut> listeAttJoueur = Helper.getPlayer().GetComponent<PlayerController>().GetAttributs();

        //clear
        clearAttributsUI(attManager);

        for (int i = 0; i < listeAttJoueur.Count; i++)
        {
            attManager.GetlistePositionJoueur().transform.GetChild(i).gameObject.SetActive(true); 
            setAttributUI(attManager.GetlistePositionJoueur().transform.GetChild(i).gameObject, listeAttJoueur[i], attManager, att.gameObject);
        }

        Attribut[] attributsObjet = att.GetComponents<Attribut>();  
        

        for(int i = 0; i < attributsObjet.Length; i++)
        {
            Debug.Log(attributsObjet[i].nom);
            attManager.GetlistePositionObjet().transform.GetChild(i).gameObject.SetActive(true);
            setAttributUI(attManager.GetlistePositionObjet().transform.GetChild(i).gameObject, attributsObjet[i], attManager, att.gameObject);
        }
    }

    public static void setAttributUI(GameObject attGO, Attribut attribut, AttributManager manager, GameObject Objet)
    {
        GameObject nom = attGO.transform.GetChild(0).gameObject;
        nom.GetComponent<Text>().text = "Nom : " + attribut.nom;
        Image img_type = attGO.transform.GetChild(1).gameObject.transform.GetComponentInChildren<Image>(); 
        GameObject Valeur = attGO.transform.GetChild(2).gameObject;

        //modifier l'image puis la valeur en fonction du type
        switch(attribut.typeAtt)
        {
            case typeAttribut.TOR:
                img_type.sprite = manager.type_sprites[2];
                if(Objet.GetComponent<TypeTOR>() != null)
                {
                    var valeur_txt = "Valeur : ";
                    switch(Objet.GetComponent<TypeTOR>().choix)
                    {
                        case true: 
                        valeur_txt += "vrai"; 
                        break; 

                        case false: 
                        valeur_txt += "faux";
                        break;
                    }
                    Valeur.GetComponent<Text>().text = valeur_txt;
                }
            break; 

            case typeAttribut.integer:
                img_type.sprite = manager.type_sprites[1];
                if(Objet.GetComponent<TypeINT>() != null)
                    Valeur.GetComponent<Text>().text = Objet.GetComponent<TypeINT>().nombre.ToString();
            break;

            case typeAttribut.ChaineDeCaractere:
                img_type.sprite = manager.type_sprites[0]; 
                var val = "Valeur : ";
                if(Objet.GetComponent<TypeSTRING>() != null)
                    val += Objet.GetComponent<TypeSTRING>().nom.ToString();
                    
                Valeur.GetComponent<Text>().text = val;    
            break; 
        }
    }

    public static void clearAttributsUI(AttributManager manager)
    {
        GameObject listePositionObjet = manager.GetlistePositionObjet(); 
        GameObject listePositionJoueur = manager.GetlistePositionJoueur(); 
        GameObject current; 
        int i;
        Text nom; 
        Image type_img; 
        Text valeur; 

        for(i = 0; i < listePositionJoueur.transform.childCount; i++)
        {
            current = listePositionJoueur.transform.GetChild(i).gameObject;
            if(!current.CompareTag("Position"))
            {
                nom = current.transform.GetChild(0).gameObject.GetComponent<Text>();
                type_img = current.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Image>(); 
                valeur = current.transform.GetChild(2).gameObject.GetComponent<Text>();

                nom.text = "Nom :";
                valeur.text = "Valeur :";
                type_img.sprite = null; 
                current.SetActive(false); 
            }
            
        }

        for(i = 0; i < listePositionObjet.transform.childCount; i++)
        {
            current = listePositionObjet.transform.GetChild(i).gameObject;
            if(!current.CompareTag("Position"))
            {
                nom = current.transform.GetChild(0).gameObject.GetComponent<Text>();
                type_img = current.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Image>(); 
                valeur = current.transform.GetChild(2).gameObject.GetComponent<Text>();

                nom.text = "Nom :";
                valeur.text = "Valeur :";
                type_img.sprite = null; 
                current.SetActive(false);
            }
        }
    }

    #endregion
}
