using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public enum canvas
    {
        general, 
        info,
        attributs, 
        dialogue, 
        pause
    }

    public canvas canvasList;

    private GameObject currentCanvas; 
    
    [SerializeField]
    private GameObject canvasGO; 

    private int canvasChild; 

    private void Awake() 
    {
        canvasGO = GameObject.Find("Canvas GUI") ?  GameObject.Find("Canvas GUI") : null; 
        canvasChild = canvasGO.transform.childCount; 
    }

    private void Update() 
    {
        if(canvasGO != null)
        {
            switch(canvasList)
            {
                case canvas.general:
                    for (int i = 0; i < canvasChild; i++)
                    {
                        currentCanvas = canvasGO.transform.GetChild(i).gameObject;
                        if(currentCanvas.transform.CompareTag("UI_general"))
                        {
                            currentCanvas.SetActive(true);
                        }
                        else
                        {
                            currentCanvas.SetActive(false);
                        }
                    }
                break; 
                case canvas.info:
                    for (int i = 0; i < canvasChild; i++)
                    {
                        currentCanvas = canvasGO.transform.GetChild(i).gameObject;
                        if(currentCanvas.transform.CompareTag("UI_info"))
                        {
                            currentCanvas.SetActive(true);
                        }
                        else
                        {
                            currentCanvas.SetActive(false);
                        }
                    }
                break; 

                case canvas.attributs:
                    for (int i = 0; i < canvasChild; i++)
                    {
                        currentCanvas = canvasGO.transform.GetChild(i).gameObject;
                        if(currentCanvas.transform.CompareTag("UI_attributs"))
                        {
                            currentCanvas.SetActive(true);
                        }
                        else
                        {
                            currentCanvas.SetActive(false);
                        }
                    }
                break; 

                case canvas.dialogue:
                    for (int i = 0; i < canvasChild; i++)
                    {
                        currentCanvas = canvasGO.transform.GetChild(i).gameObject;
                        if(currentCanvas.transform.CompareTag("UI_dialogue") || currentCanvas.transform.CompareTag("UI_general"))
                        {
                            currentCanvas.SetActive(true);
                        }
                        else
                        {
                            currentCanvas.SetActive(false);
                        }
                    }
                break; 

                case canvas.pause:
                    for (int i = 0; i < canvasChild; i++)
                    {
                        currentCanvas = canvasGO.transform.GetChild(i).gameObject;
                        if(currentCanvas.transform.CompareTag("UI_pause"))
                        {
                            Helper.getPlayer().GetComponent<PlayerController>().gameIsPaused = true; 
                            Helper.getPlayer().GetComponent<PlayerController>().checkPause();
                            currentCanvas.SetActive(true);
                        }
                        else
                        {
                            Helper.getPlayer().GetComponent<PlayerController>().gameIsPaused = false; 
                            Helper.getPlayer().GetComponent<PlayerController>().checkPause();
                            currentCanvas.SetActive(false);
                        }
                    }
                break;    
            }
        }
    }

    public void changeCanvas(canvas choix)
    {
        canvasList = choix;
    }

}
