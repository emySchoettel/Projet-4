using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    public enum emotionsCreateur
    {
        naturel,
        enerve,
        triste,
        espiegle,
        rire

    }
    public static void changerCreateurSprite(GameObject createur, emotionsCreateur emotion)
    {
        createur.GetComponent<DieuxComportement>().setSprite(emotion);
    }
}
