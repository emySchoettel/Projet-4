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
    }

    public List<DialogueSaisie> dialogues = new List<DialogueSaisie>();

    [SerializeField]
    private bool finished = false;
    public GameObject canvas;
    public Text speaker, text; 
    public IntroductionJoueur joueur_sc; 

 
    public IEnumerator ShowText(List<DialogueSaisie> dialogues, int tour)
    { 
        canvas.SetActive(true);
        
        yield return ReadText(dialogues[tour]);
           
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
    
    public List<DialogueSaisie> GetDialogues()
    {
        return dialogues;
    }
}
