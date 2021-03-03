using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesCreateurs : MonoBehaviour
{
    [System.Serializable]
    public class DialogueClass
    {
        public DieuxComportement.createurs parleur; 
        public DieuxComportement.emotionsCreateur emotions;
        public Helper.speakers speakers; 
        [TextArea]
        public string text = ""; 
        [Range(0.0f, 1f)]
        public float letterperSecond = 0.2f;
        public AudioSource phrase_audio;
    }
    public List<DialogueClass> dialogues = new List<DialogueClass>();
    public DialogueManager.cinematiques_enum enum_cinematiques;


    //public List<Abs_cinematiques> cinematiques = new List<Abs_cinematiques>();
    private bool finished = false; 
    public Text sstitre; 
    public Text prenomsstitre; 

    [SerializeField]
    private GameObject Emy, Gaetan;
    private int i = 0;
    private Abs_cinematiques abs_Cinematiques;
    
    private void Awake() 
    {
        switch(enum_cinematiques)
        {
            case DialogueManager.cinematiques_enum.introduction:
            introduction intro = gameObject.AddComponent<introduction>();
            StartState(intro);
            break; 
        }
        sstitre.text = "";
        prenomsstitre.text = "";
    }

    public void StartState(Abs_cinematiques cine)
    {
        abs_Cinematiques = cine; 
        cine.Enter(this);
    }

    public GameObject getCreateurEmy()
    {
        return Emy;
    }

    public GameObject getCreateurGaetan()
    {
        return Gaetan; 
    }
    public bool getFinished()
    {
        return finished;
    }

    public void setFinish(bool choix)
    {
        finished = choix;
    }

    //  IEnumerator ShowTextIntroduction(List<DialogueClass> dialogues)
    // {
    //     GameObject createurActuel = null; 
    //     DieuxComportement createurActuelComportement = null; 
    //     for(i = 0; i < dialogues.Count; i++)
    //     {
    //         createurActuel = getCreateurActuel(); 
    //         createurActuelComportement = createurActuel.GetComponent<DieuxComportement>(); 
    //         lancerAnimationCreateur(createurActuelComportement, true);
         
    //         if(dialogues[i].speakers == Helper.speakers.None)
    //         {
    //             createurActuelComportement.changeSprite(dialogues[i].emotions);
    //         }
    //         if(dialogues[i].phrase_audio != null)
    //         {
    //             dialogues[i].phrase_audio.Play();
    //         }
    //         if(i == 11) //entrée de Solabis
    //         {
    //             Debug.Log("Entrée de solabis");
    //             yield return new WaitForSeconds(2f); //TODO ou le temps qu'il faudra
    //             i++;
    //             yield return ReadText(dialogues[i]);
    //         }
    //         else
    //         {
    //             yield return ReadText(dialogues[i]);
    //             lancerAnimationCreateur(createurActuelComportement, false);
    //         }
    //     }
    //     yield return conditionsFin();
    // }
    // IEnumerator ReadText(DialogueClass dialogue)
    // {

    //     string texteActuel = "";
    //     string currentText = "";
        
    //     //Si le parleur n'est pas Solabis alors utiliser la liste des créateurs
    //     if(dialogue.speakers == Helper.speakers.None)
    //     {
    //         prenomsstitre.text = dialogue.parleur.ToString();
    //     }
    //     else
    //     {
    //         prenomsstitre.text = dialogue.speakers.ToString();
    //     }
    //     texteActuel = dialogue.text;
    //     for(int j = 0; j <= texteActuel.Length; j++)
    //     {
    //         currentText = texteActuel.Substring(0,j);
    //         sstitre.text = currentText;
    //         yield return new WaitForSeconds(dialogue.letterperSecond);
    //     }
    //     //yield return new WaitForSeconds(dialogue.phrase_audio.clip.length + 1f);
    //     yield return new WaitForSeconds(3f);
    // }   

    // public IEnumerator conditionsFin()
    // {
    //     finished = true; 
    //     fermerDialogue();
    //     yield return null; 
    // }
    // public void fermerDialogue()
    // {
    //     i = 0;
    //     finished = true; 
    //     sstitre.text = "";
    //     prenomsstitre.text = ""; 
    // } 

    // private GameObject getCreateurActuel()
    // {
    //     GameObject res = null; 
    //     switch(dialogues[i].parleur)
    //     {
    //         case DieuxComportement.createurs.Emy:
    //             res = Emy; 
    //         break; 

    //         case DieuxComportement.createurs.Gaetan: 
    //             res = Gaetan; 
    //         break;  
    //     }
    //     return res; 
    // }

    // private void lancerAnimationCreateur(DieuxComportement createurActuelComportement, bool choix)
    // {
    //     Animator animCreateur = createurActuelComportement.GetComponent<Animator>();
    //     if(choix)
    //     {
    //         switch(createurActuelComportement.getCreateurType())
    //         {
    //             case DieuxComportement.createurs.Emy:
    //                 animCreateur.SetInteger("Createur", 1);
    //             break; 

    //             case DieuxComportement.createurs.Gaetan:
    //                 animCreateur.SetInteger("Createur", 1);
    //             break; 
    //         }
    //     }
    //     else
    //     {
    //         animCreateur.SetInteger("Createur", 0);
    //     }
    //     Debug.Log(animCreateur.GetInteger("Createur"));
        
    // }
}
