using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introduction : MonoBehaviour, Abs_cinematiques
{
    private int i = 0;
    private bool playing = true; 
    private DialoguesCreateurs createurs;
    public void Enter(DialoguesCreateurs diag)
    {
        diag.getCreateurEmy().GetComponent<DieuxComportement>().changeSprite(DieuxComportement.emotionsCreateur.naturel);
        diag.getCreateurGaetan().GetComponent<DieuxComportement>().changeSprite(DieuxComportement.emotionsCreateur.naturel);
        StartCoroutine(ShowText(diag));
        diag.audio.enabled = true;
        createurs = diag;
    }

    public IEnumerator ShowText(DialoguesCreateurs diag)
    {
        GameObject createurActuel = null; 
        DieuxComportement createurActuelComportement = null; 
        for(i = 0; i < diag.dialogues.Count; i++)
        {
            createurActuel = getCreateurActuel(diag); 
            createurActuelComportement = createurActuel.GetComponent<DieuxComportement>(); 
            lancerAnimationCreateur(createurActuelComportement, true);
         
            if(diag.dialogues[i].speakers == Helper.speakers.None)
            {
                createurActuelComportement.changeSprite(diag.dialogues[i].emotions);
            }
            else
            {
                createurActuelComportement = diag.getCreateurEmy().GetComponent<DieuxComportement>();
                lancerAnimationCreateur(createurActuelComportement, false);
                createurActuelComportement = diag.getCreateurGaetan().GetComponent<DieuxComportement>();
                lancerAnimationCreateur(createurActuelComportement, false);
            }
            if(diag.dialogues[i].phrase_audio != null)
            {
                diag.audio.clip = diag.dialogues[i].phrase_audio;
                diag.audio.Play();
            }
            if(i == 11) //entrée de Solabis
            {
                lancerAnimationCreateur(createurActuelComportement, false);
                yield return new WaitForSeconds(2f); 
                diag.getSolabis().transform.position = new Vector3(diag.getSolabis().transform.position.x, diag.getSolabis().transform.position.y, -5.6f);
                i++;
                diag.audio.clip = diag.dialogues[i].phrase_audio;
                diag.audio.Play();
                yield return ReadText(diag);
            }
            else
            {
                yield return ReadText(diag);
                lancerAnimationCreateur(createurActuelComportement, false);
            }
        }
        yield return conditionsFin(diag);
        yield return null; 
    }

    public IEnumerator ReadText(DialoguesCreateurs diag)
    {
        string texteActuel = "";
        string currentText = "";

        //Si le parleur n'est pas Solabis alors utiliser la liste des créateurs
        if(diag.dialogues[i].speakers == Helper.speakers.None)
        {
            diag.prenomsstitre.text = diag.dialogues[i].parleur.ToString();
        }
        else
        {
            diag.prenomsstitre.text = diag.dialogues[i].speakers.ToString();
        }
        texteActuel = diag.dialogues[i].text;
        for(int j = 0; j <= texteActuel.Length; j++)
        {
            currentText = texteActuel.Substring(0,j);
            diag.sstitre.text = currentText;
            yield return new WaitForSeconds(diag.dialogues[i].letterperSecond);
        }

        while(diag.audio.isPlaying == true)
        {
            yield return null;
        }
    }
     public GameObject getCreateurActuel(DialoguesCreateurs diag)
    {
        GameObject res = null; 
        switch(diag.dialogues[i].parleur)
        {
            case DieuxComportement.createurs.Emy:
                res = diag.getCreateurEmy(); 
            break; 

            case DieuxComportement.createurs.Gaetan: 
                res = diag.getCreateurGaetan(); 
            break;  
        }
        return res; 
    }

    public void lancerAnimationCreateur(DieuxComportement createurActuelComportement, bool choix)
    {
        Animator animCreateur = createurActuelComportement.GetComponent<Animator>();
        if(choix)
        {
            animCreateur.SetInteger("Createur", 1);
        }
        else
        {
            animCreateur.SetInteger("Createur", 0);
        }
    }

    public IEnumerator conditionsFin(DialoguesCreateurs diag)
    {
        diag.setFinish(true);
        fermerDialogue(diag);
        yield return null; 
    }
    public void fermerDialogue(DialoguesCreateurs diag)
    {
        i = 0;
        diag.setFinish(true);
        diag.sstitre.text = "";
        diag.prenomsstitre.text = ""; 
    } 
}
