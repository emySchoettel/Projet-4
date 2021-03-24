using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionManager : MonoBehaviour
{
    //Dialogue
  [System.Serializable]
    public class DialogueSaisie
    {
        public Helper.speakers parleur; 
        [TextArea]
        public string text = ""; 
        [Range(0.0f, 1f)]
        public float letterperSecond = 0.2f;

        public Expression.nomsExpressions expressions;
    
        public GameObject self; 

        public FontStyle fontStyle; 
    }

    public List<DialogueSaisie> dialoguesIntroJoueur = new List<DialogueSaisie>();
    public List<DialogueSaisie> dialoguesSolabis = new List<DialogueSaisie>(); 

    [SerializeField]
    private bool finished = false;

    private int i = 0; 
    public GameObject canvas;
    public Text speaker, text; 
    public IntroductionJoueur joueur_sc; 

    public GameObject Solabis; 

    [SerializeField]
    private GameObject mainCamera; 

    private void Awake() {
        mainCamera = GameObject.Find("MainCamera");
    }

 
    public IEnumerator ShowTextIntro(List<DialogueSaisie> dialogues, int tour)
    { 
        joueur_sc.stop = true; 
        canvas.SetActive(true);
        
        yield return ReadText(dialogues[tour]);
           
        yield return conditionsFin();
        joueur_sc.stop = false; 
    }

    public IEnumerator ShowTextSolabis(List<DialogueSaisie> dialogues)
    {
        canvas.SetActive(true);
        for(i = 0; i < dialogues.Count; i++)
        {
            yield return ReadText(dialogues[i]);
        }
        yield return conditionsFin(); 
    }


    IEnumerator ReadText(DialogueSaisie dialogue)
    {
        joueur_sc.setIDLE();

        text.fontStyle = dialogue.fontStyle;
        if(dialogue.expressions != Expression.nomsExpressions.None)
        {
            if(dialogue.self != null)
            {
                Helper.addExpression(dialogue.self, dialogue.expressions);
            }
        }

        string texteActuel = "";
        string currentText = "";

        speaker.text = dialogue.parleur.ToString();

        texteActuel = dialogue.text;
        for(int j = 0; j <= texteActuel.Length; j++)
        {
            currentText = texteActuel.Substring(0,j);
            text.text = currentText;
            yield return new WaitForSeconds(dialogue.letterperSecond);
        }

        yield return new WaitForSeconds(1f);
    }   

    public void CinematiqueSolabis()
    {
        //TODO deplacer la camera et lancer la discussion 
        Debug.Log("Solabis ici");
    }

    public IEnumerator conditionsFin()
    {
        finished = true; 
        canvas.SetActive(false);
        yield return null; 
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
    
    public List<DialogueSaisie> GetDialoguesIntroJoueur()
    {
        return dialoguesIntroJoueur;
    }

    
}
