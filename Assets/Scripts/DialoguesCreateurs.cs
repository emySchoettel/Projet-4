using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesCreateurs : MonoBehaviour
{
   [System.Serializable]
    public class DialogueSaisie
    {
        public DieuxComportement.createurs parleur; 
        [TextArea]
        public string text = ""; 
        [Range(0.0f, 1f)]
        public float letterperSecond = 0.2f;
    }

    public List<DialogueSaisie> dialogues = new List<DialogueSaisie>();
    private bool finished = false; 

    public GameObject dialogues_gm;
    private int i = 0;

    private Text dialogues_txt; 

    private void OnEnable() 
    {
        if(!finished)
        {
            dialogues_gm.SetActive(true);
            StartCoroutine(ShowText(dialogues));
        }
    }

     IEnumerator ShowText(List<DialogueSaisie> dialogues)
    {
        for(i = 0; i < dialogues.Count; i++)
        {
            yield return ReadText(dialogues[i]);
        }
        yield return conditionsFin();
    }
    IEnumerator ReadText(DialogueSaisie dialogue)
    {
        string texteActuel = "";
        string currentText = "";

        //Si le dialogue n'est pas automatique et si le dialogue actuel n'est pas terminé 
        dialogueManager.speaker.text = dialogue.parleur.ToString();

        texteActuel = dialogue.text;
        for(int j = 0; j <= texteActuel.Length; j++)
        {
            currentText = texteActuel.Substring(0,j);
            dialogueManager.dialogue_gm.text = currentText;
            yield return new WaitForSeconds(dialogue.letterperSecond);
        }
        if(automatique_dialogue)
        {
            yield return new WaitForSeconds(2f);
        }
    }   

    public IEnumerator conditionsFin()
    {
        if(i == dialogues.Count && !automatique_dialogue)
        {
            yield return new WaitUntil(() => keyPressed);
            fermerDialogue();
        }
        if(automatique_dialogue)
        {
            finished = true; 
            fermerDialogue();
        }
    }
    public void fermerDialogue()
    {
        i = 0;
        finished = true; 
        GameObject.Find("Canvas").SetActive(false);
    } 


}
