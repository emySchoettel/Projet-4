using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Abs_cinematiques 
{
    void Enter(DialoguesCreateurs diag);
    IEnumerator ShowText(DialoguesCreateurs diag); 
    IEnumerator ReadText(DialoguesCreateurs diagCrea);
    GameObject getCreateurActuel(DialoguesCreateurs diag);

    void lancerAnimationCreateur(DieuxComportement createurActuelComportement, bool choix);
    IEnumerator conditionsFin(DialoguesCreateurs diag);

    void fermerDialogue(DialoguesCreateurs diag);
}
