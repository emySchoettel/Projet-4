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
        StartState(etatdroite);
    }

    public void StartState(EtatMouvementJoueur joueur)
    {
        etat = joueur;
        joueur.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
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
