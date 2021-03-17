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

        public Expression.nomsExpressions expressions;
    
        public GameObject self; 
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
    {   GameObject.FindGameObjectWithTag("Player").GetComponent<MouvementJoueur>().stopMouvement = true; 
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>();
         if(!finished && dialogueManager != null)
        {
            DialogueManager.AddObserver(this);
            dialogueManager.getCanvas().SetActive(true);
            StartCoroutine(ShowText(dialogues));
        }
    }
 
    IEnumerator ShowText(List<DialogueSaisie> dialogues)
    {
        for(i = 0; i < dialogues.Count; i++)
        {
            if(i == 0)
            {
                yield return ReadText(dialogues[i]);
            }
            else if(i > 0 && !automatique_dialogue)
            {
                while(!Input.GetKey(KeyCode.Space))
                {
                    yield return null;
                }
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
        if(dialogue.expressions != Expression.nomsExpressions.None)
        {
            if(dialogue.self != null)
            {
                Helper.addExpression(dialogue.self, dialogue.expressions);
            }
        }

        string texteActuel = "";
        string currentText = "";

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
            yield return new WaitForSeconds(1f);
        }
    }   

    public IEnumerator conditionsFin()
    {
        if(i == dialogues.Count && !automatique_dialogue)
        {
            while(!Input.GetKey(KeyCode.E))
            {
                yield return null;
            }
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
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouvementJoueur>().stopMouvement = false;
        dialogueManager.getCanvas().SetActive(false);
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
