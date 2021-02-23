using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTest : MonoBehaviour, Observer
{
    [System.Serializable]
    public class DialogueSaisie
    {
        public Helper.speakers importants; 
        [TextArea]
        public string text = ""; 
        [Range(0.0f, 1f)]
        public float letterperSecond = 0.2f;
        public bool finished = false; 
    }

    public List<DialogueSaisie> dialogues = new List<DialogueSaisie>();
    public bool automatique_dialogue = false; 
    public bool automatique_trigger = false; 

    [SerializeField]
    private bool finished = false;

    [SerializeField]
    private Text dialogue_gm, speaker; 
    [SerializeField]
    private GameObject canvas; 

    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(!finished)
        {
            DialogueManager.AddObserver(this);
            canvas.SetActive(true);
            StartCoroutine(ShowText(dialogues));
        }
    }
    IEnumerator ShowText(List<DialogueSaisie> dialogues)
    {
        // while(i < dialogues.Count && !dialogues[i].finished)
        // {
        //     yield return ReadText(dialogues[i]);
        // }
        for(int i = 0; i < dialogues.Count; i++)
        {
            yield return ReadText(dialogues[i]);
        }
        finished = true; 
        yield return null;
    }

    IEnumerator ReadText(DialogueSaisie dialogue)
    {
        string texteActuel = "";
        string currentText = "";

        //Si le dialogue n'est pas automatique et si le dialogue actuel n'est pas terminé 
        //TODO ajouter le nom du joueur qui s'affiche
        if(!automatique_dialogue)
        {
            if(!dialogue.finished)
            {
                texteActuel = dialogue.text;
                Debug.Log(texteActuel);
                for(int j = 0; j <= texteActuel.Length; j++)
                {
                    //Notify();
                    currentText = texteActuel.Substring(0,j);
                    dialogue_gm.text = currentText;
                    yield return new WaitForSeconds(dialogue.letterperSecond);
                }
                //StartCoroutine(NextText(dialogue));
            }
        }
    }   

    IEnumerator NextText(DialogueSaisie dialogue)
    {
        while(!Input.GetKeyDown(KeyCode.Space) && !dialogue.finished)
        {
            Notify();
        }   
        dialogue.finished = true; 
        i++;
        yield return null;
    }   
    public void Notify()
    {
        Debug.Log("Observer");
    }
}
