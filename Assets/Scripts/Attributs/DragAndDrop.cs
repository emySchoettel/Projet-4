using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]

public abstract class IDragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    protected RectTransform rectTransform;
    protected Image image; 
    protected bool correctementPlace = true; 

    protected AttributManager attributManager; 
    //public abstract void Awake();
    public abstract void OnDrag(PointerEventData eventData);
   
    public abstract void OnBeginDrag(PointerEventData eventData);
   
    public abstract void OnEndDrag(PointerEventData eventData);


    public abstract void OnPointerDown(PointerEventData eventData);

    public abstract Image GetImage();
}
