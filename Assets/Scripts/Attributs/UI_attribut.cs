using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UI_attribut : MonoBehaviour
{
    [SerializeField]
    private Image img; 
    [SerializeField]
    private bool blink = false, click = false; 
    private void Update() 
    {
        if(Input.GetMouseButton(0) && !click)
        {
            click = true; 
            prepareBlinkFunc(false);
        }
        else if(Input.GetMouseButton(0) && click)
        {
            blink = false;
        }       
    }

    private IEnumerator makeBlink()
    {
        while(blink)
        {
            Debug.Log("Make blind function");
            img.enabled = true;
            StartCoroutine(waitForThreeSeconds());
            img.enabled = false;  
            if(!blink) break; 
        }
        yield return null;
    }

    private IEnumerator waitForThreeSeconds()
    {
        yield return new WaitForSeconds(3f);
    }

    private IEnumerator prepareBlinkEnum()
    {
        yield return makeBlink();
    }

    private void prepareBlinkFunc(bool choix)
    {
       
        if(!choix)
        {
            click = true; 
            blink = true;
            StartCoroutine(makeBlink());
            
        }
    }
}
