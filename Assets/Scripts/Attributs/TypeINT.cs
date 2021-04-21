using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeINT : TypeAbs
{
    public int nombre; 
    public override void enter(Attribut att)
    {

    }

    public override void update(Attribut att)
    {
      switch(att.type)
        {
            case Helper.typeAttribut.ChaineDeCaractere:
                att.StartState(att.typeString);
            break;

            case Helper.typeAttribut.TOR:
                att.StartState(att.typeTor);
            break;
        }
    }
}
