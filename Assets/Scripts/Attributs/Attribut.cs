using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribut : MonoBehaviour
{
    [SerializeField]
    private  Helper.progressionAttributs progressionAttribut;
    [SerializeField]
    private Helper.typeAttribut type; 

    public void setTypeAttribut(Helper.typeAttribut nouveauType)
    {
        type = nouveauType;
    }

    public void setProgressionAttribut(Helper.progressionAttributs prog)
    {
        progressionAttribut = prog; 
    }

    public Helper.typeAttribut GetTypeAttribut()
    {
        return type; 
    }
    private void OnTriggerEnter(Collider other) 
    {
        Helper.addExpression(Helper.getPlayer(), Expression.nomsExpressions.Exclamation);
    }
}
