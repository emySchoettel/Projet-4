using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeTOR : TypeAbs
{
    public bool choix;

    public override void enter(Attribut att)
    {
        Debug.Log("type TOR");
    }

    public override void update(Attribut att)
    {
        switch(att.type)
        {
            case Helper.typeAttribut.ChaineDeCaractere:
                att.StartState(att.typeString);
            break;

            case Helper.typeAttribut.integer:
                att.StartState(att.typeInt);
            break;
        }
    }
}
