using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{

    #region variables

    public float speed = 100f; 
    private Rigidbody rgbody; 

    private Animator animationActuelle;

    private EtatMouvementJoueur etat; 
    public MouvementGauche etatgauche = new MouvementGauche();
    public MouvementDroite etatdroite = new MouvementDroite();

    public MouvementHaut etathaut = new MouvementHaut();
    public MouvementBas etatbas = new MouvementBas();

    public Helper.directions direction; 

    public List<Observer> observers; 

    #endregion

    private void Awake() 
    {
        rgbody = GetComponent<Rigidbody>();
        animationActuelle = GetComponent<Animator>(); 
        observers = new List<Observer>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        StartState(etatbas);
    }

    public void StartState(EtatMouvementJoueur joueur)
    {
        etat = joueur;
        joueur.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        // float x = Input.GetAxisRaw("Horizontal");
        // float z = Input.GetAxisRaw("Vertical");

        // if(Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     Debug.Log("Gauche");
        //     Debug.Log(x);
        //     Debug.Log(z);
        // }
        // else if(Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     Debug.Log("Droit");
        //     Debug.Log(x);
        //     Debug.Log(z);
        // }
        // if(Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     Debug.Log("Haut");
        //     Debug.Log(x);
        //     Debug.Log(z);
        // }
        // else if(Input.GetKeyDown(KeyCode.DownArrow))
        // {
        //     Debug.Log("Bas");
        //     Debug.Log(x);
        //     Debug.Log(z);
        // }
                
        etat.Update(this);

    }

    #region accesseurs

    public Rigidbody getRigidBody()
    {
        return rgbody; 
    }

    public Animator GetAnimator()
    {
        return animationActuelle;
    }
    #endregion

    #region Observer

    public void AddObserver(Observer obs)
    {
        observers.Add(obs);
    }

    public void RemoveObserver(Observer obs)
    {
        observers.Remove(obs);
    }

    public void Notify()
    {
        foreach(Observer obs in observers)
        {
            obs.Notify(); 
        }
    }
    
    #endregion
}
