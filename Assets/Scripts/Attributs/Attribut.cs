using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribut : MonoBehaviour
{
    public string nom;
    public string description;
    public  Helper.mondes monde;
    public Helper.typeAttribut typeAtt; 

  //  private TypeAbs typeAbs;
    public TypeINT typeInt; 
    public TypeSTRING typeString; 
    public TypeTOR typeTor;
    private void Start() 
    {
       // StartState(typeTor);
    }

    public Attribut(string nom, string description, Helper.mondes mondes, Helper.typeAttribut attribut)
    {
        this.nom = nom; 
        this.description = description; 
        monde = mondes; 
        typeAtt = attribut;
    }

    public void setTypeTOR(TypeTOR tor)
    {
        typeTor = tor;
    }
    private void Update() 
    {
        // if(!gameObject.transform.CompareTag("Player"))
        // {
        //     typeAbs.update(this); 
        // }  
    }

    public void StartState(TypeAbs type)
    {
        //typeAbs = type;
        //type.enter(this);

    // if(GetComponent<TypeINT>() != null || GetComponent<TypeTOR>() != null || GetComponent<TypeSTRING>() != null)
    //     switch(typeAtt)
    //     {
    //         case Helper.typeAttribut.integer:
    //             typeInt = GetComponent<TypeINT>();
    //         break; 

    //         case Helper.typeAttribut.TOR:
    //             typeTor = GetComponent<TypeTOR>();
    //         break; 

    //         case Helper.typeAttribut.ChaineDeCaractere:
    //             typeString = GetComponent<TypeSTRING>();
    //         break; 
    //     }
        
        if(!gameObject.transform.CompareTag("Player"))
        {
           // manageComponentType();
        }
    }

    public void manageComponentType()
    {
        // switch(typeAbs.GetType().ToString())
        // {
        //     case "TypeINT":
        //         //ajout du type int
        //         gameObject.AddComponent<IntCMP>(); 

        //         //destroy des autres types 
        //         if(gameObject.GetComponent<TorCMP>())
        //             Destroy(GetComponent<TorCMP>());
        //         if(gameObject.GetComponent<StringCMP>())
        //             Destroy(GetComponent<StringCMP>());

        //     break; 

        //     case "TypeTOR":
        //         //ajout du type bool
        //         gameObject.AddComponent<TorCMP>(); 

        //         //destroy ceux existant
        //         if(gameObject.GetComponent<IntCMP>())
        //             Destroy(GetComponent<IntCMP>());
        //         if(gameObject.GetComponent<StringCMP>())
        //             Destroy(GetComponent<StringCMP>());
        //     break; 

        //     case "TypeSTRING":
        //         //ajout du type string
        //         gameObject.AddComponent<StringCMP>(); 

        //         //destroy ceux existant
        //         if(gameObject.GetComponent<IntCMP>())
        //             Destroy(GetComponent<IntCMP>());
        //         if(gameObject.GetComponent<TorCMP>())
        //             Destroy(GetComponent<TorCMP>());
        //     break; 
        // }
    }
    
 
}
