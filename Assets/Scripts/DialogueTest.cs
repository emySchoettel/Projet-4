using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTest : MonoBehaviour, Observer
{
    [System.Serializable]
    public class DialogueSaisie
    {
        public Helper.speakers parleur; 
        [TextArea]
        public string text = ""; 
        [Range(0.0f, 1f)]
        public float letterperSecond = 0.2f;
        //public bool finished = false; 
    }

    public List<DialogueSaisie> dialogues = new List<DialogueSaisie>();
    public bool automatique_dialogue = false;
    private bool keyPressed = false; 

    [SerializeField]
    private bool finished = false;
    private int i = 0;
    private DialogueManager dialogueManager; 
    // Start is called before the first frame update
    private void OnEnable() 
    {
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
         if(!finished && dialogueManager != null)
        {
            DialogueManager.AddObserver(this);
            dialogueManager.canvas.SetActive(true);
            StartCoroutine(ShowText(dialogues));
        }
    }
 
    private void Update() 
    {
        if(!automatique_dialogue)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                keyPressed = true; 
            }
            else if(Input.GetKeyUp(KeyCode.Space))
            {
                keyPressed = false; 
            }
        }
    }

    IEnumerator ShowText(List<DialogueSaisie> dialogues)
    {
        for(i = 0; i < dialogues.Count; i++)
        {
            //Ne pas intervenir pour le premier dialogue
            if(i == 0)
            {
                yield return ReadText(dialogues[i]);
            }
            else if(i > 0 && !automatique_dialogue)
            {
                yield return new WaitUntil(() => keyPressed);
                yield return ReadText(dialogues[i]);
                
            }
            else if(i > 0 && automatique_dialogue)
            {
                yield return ReadText(dialogues[i]);
            }
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

    public void Notify()
    {
        Debug.Log("Observer");
    }

    public bool getFinished()
    {
        return finished;
    }

    public void stopFinished()
    {
        finished = false; 
        this.enabled = false;
    }


}
