using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeSTRING : TypeAbs
{
    public string nom;

    public override void enter(Attribut att)
    {
        
    }

    public override void update(Attribut att)
    {
        switch(att.type)
        {
            case Helper.typeAttribut.integer:
                att.StartState(att.typeInt);
            break;

            case Helper.typeAttribut.TOR:
                att.StartState(att.typeTor);
            break;
        }
    }

}
