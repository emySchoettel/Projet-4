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


    private static List<Attribut> attributs = new List<Attribut>(); //inventaire des attributs

    public static bool gameIsPaused;
    public GameObject UiPause;

    public List<Attribut> GetAttributs()
    {
        return attributs; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
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
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            UiPause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
            UiPause.SetActive(false);

        }
    }
}
