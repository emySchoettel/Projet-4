using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static string nomJoueur = "Le joueur"; 
    [SerializeField]

    private RuntimeAnimatorController[] animators = null; 
    public bool introduction = false; 

    [SerializeField]
    private bool movePlayer = true; 

    [SerializeField]
    private List<Attribut> attributs = new List<Attribut>(); //inventaire des attributs

    [SerializeField]
    public bool gameIsPaused = false;
    public GameObject UiPause;

    public List<Attribut> GetAttributs()
    {
        return attributs; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!gameIsPaused)
            {   
                gameIsPaused = true; 
                checkPause();
            }
            else
            {
                gameIsPaused = false; 
                checkPause();
            }
        }
    }

    private void Awake() 
    {
        
        if (introduction)
        {
            GetComponent<Animator>().runtimeAnimatorController = animators[1]; 
        }
        else
        {
            if(GetComponent<MouvementJoueur>().enabled)
            {
                GetComponent<Animator>().runtimeAnimatorController = animators[0];
            }
        }

        if(UiPause == null)
        {
            UiPause = GameObject.Find("UI_Pause");
        }
    }

    public void setAnimator(int i)
    {
        GetComponent<Animator>().runtimeAnimatorController = animators[i];
        if(i == 1)
        {
            introduction = false; 
            movePlayer = true; 
            GetComponent<MouvementJoueur>().enabled = true; 
        }
    }

    public void checkPause()
    {
        if(gameIsPaused)
        {
            PauseGame(); 
        }
        else
        {
            UnpauseGame(); 
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        GameObject.FindObjectOfType<CanvasManager>().changeCanvas(CanvasManager.canvas.pause);
    }

    void UnpauseGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        GameObject.FindObjectOfType<CanvasManager>().changeCanvas(CanvasManager.canvas.general);
    }   
}
