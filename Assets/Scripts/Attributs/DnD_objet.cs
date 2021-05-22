using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DnD_objet : IDragAndDrop
{
   private void Awake() 
    {
        rectTransform = GetComponent<RectTransform>(); 
        image = GetComponent<Image>(); 
        if(image != null)
        {
            image.color = new Color(0.5754f,0.2850f,0.2850f, 1f);
        }

        attributManager = GameObject.FindObjectOfType<AttributManager>();
    }

    public override void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;  
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        image.enabled = true; 

    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        image.enabled = false; 
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
    
    }

    public override Image GetImage()
    {
        return image;
    }

    private void OnTriggerEnter(Collider other) 
    {
        // if(other.CompareTag("Position"))
        // {
        //     if(other.transform.parent.gameObject == attributManager.listeObjet && other.transform.gameObject.activeSelf)
        //     {
        //         Debug.Log("Replacer l'item");
        //         other.transform.gameObject.GetComponent<DnD_Joueur>().GetImage().color = new Color(); 
        //         other.transform.gameObject.GetComponent<DnD_Joueur>().GetImage().enabled = true;
                
        //         //TODO Effectuer l'échange

        //     }
        // }
    }
}
