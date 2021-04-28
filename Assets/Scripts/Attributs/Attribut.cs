using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TypeAbs))]
public class Attribut : MonoBehaviour
{
    public string nom;
    public string description;
    public  Helper.mondes monde;
    public Helper.typeAttribut type; 

    private TypeAbs typeAbs;
    public TypeINT typeInt = new TypeINT(); 
    public TypeSTRING typeString = new TypeSTRING(); 
    public TypeTOR typeTor = new TypeTOR();

    private void Start() 
    {
        StartState(typeTor);
    }
    private void Update() 
    {
        
        if(!gameObject.transform.CompareTag("Player"))
        {
            typeAbs.update(this); 
        }
       
    }

    public void StartState(TypeAbs type)
    {
        typeAbs = type;
        type.enter(this);
        if(!gameObject.transform.CompareTag("Player"))
        {
            manageComponentType();
        }
    }

    public void manageComponentType()
    {
        switch(typeAbs.GetType().ToString())
        {
            case "TypeINT":
                //ajout du type int
                gameObject.AddComponent<IntCMP>(); 

                //destroy des autres types 
                if(gameObject.GetComponent<TorCMP>())
                    Destroy(GetComponent<TorCMP>());
                if(gameObject.GetComponent<StringCMP>())
                    Destroy(GetComponent<StringCMP>());

            break; 

            case "TypeTOR":
                //ajout du type bool
                gameObject.AddComponent<TorCMP>(); 

                //destroy ceux existant
                if(gameObject.GetComponent<IntCMP>())
                    Destroy(GetComponent<IntCMP>());
                if(gameObject.GetComponent<StringCMP>())
                    Destroy(GetComponent<StringCMP>());
            break; 

            case "TypeSTRING":
                //ajout du type string
                gameObject.AddComponent<StringCMP>(); 

                //destroy ceux existant
                if(gameObject.GetComponent<IntCMP>())
                    Destroy(GetComponent<IntCMP>());
                if(gameObject.GetComponent<TorCMP>())
                    Destroy(GetComponent<TorCMP>());
            break; 
        }
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.CompareTag("Player"))
        {
            Debug.Log("player");
            Helper.addExpression(Helper.getPlayer(), Expression.nomsExpressions.Exclamation); 
        }
    }

    private void OnTriggerStay(Collider other) 
    {
         if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Echange en cours"); 
                Helper.addAttributPlayer(this);
                foreach(Attribut att in Helper.getPlayer().GetComponent<PlayerController>().GetAttributs())
                {
                    Debug.Log(att.nom);
                    Debug.Log(att.typeAbs.GetType().ToString());
                    Destroy(this);
                }
            }
    }
}
