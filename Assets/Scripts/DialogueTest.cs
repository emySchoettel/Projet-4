using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTest : MonoBehaviour, Observer
{
    [System.Serializable]
    public class DialogueSaisie
    {
        public Helper.speakers nomsDicteur; 
        [TextArea]
        public string text = ""; 
        [Range(0.0f, 1f)]
        public float letterperSecond = 0.2f;
        public bool finished = false; 
    }

    public List<DialogueSaisie> dialogues = new List<DialogueSaisie>();
    public bool automatique_dialogue = false, automatique_trigger = false; 
    private bool keyPressed = false; 

    [SerializeField]
    private bool finished = false;

    [SerializeField]
    private Text dialogue_gm, speaker; 
    [SerializeField]
    private GameObject canvas; 

    private int i = 0;
    // Start is called before the first frame update
    private void OnEnable() {
         if(!finished)
        {
            DialogueManager.AddObserver(this);
            canvas.SetActive(true);
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
        if(finished)
        {
            fermerDialogue();
        }
    }

    IEnumerator ShowText(List<DialogueSaisie> dialogues)
    {
        for(i = 0; i < dialogues.Count; i++)
        {
            if(i == 0)
            {
                Debug.Log("read");
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
        speaker.text = dialogue.nomsDicteur.ToString();
        if(!automatique_dialogue)
        {
            if(!dialogue.finished)
            {
                texteActuel = dialogue.text;
                for(int j = 0; j <= texteActuel.Length; j++)
                {
                    //Notify();
                    currentText = texteActuel.Substring(0,j);
                    dialogue_gm.text = currentText;
                    yield return new WaitForSeconds(dialogue.letterperSecond);
                }
            }
        }
    }   

    public IEnumerator conditionsFin()
    {
        if(i == dialogues.Count)
        {
            yield return new WaitUntil(() => keyPressed);
            fermerDialogue();
        }
        if(automatique_dialogue)
        {
            finished = true; 
        }
    }
    public void fermerDialogue()
    {
        i = 0;
        finished = true; 
        canvas.SetActive(false);
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
