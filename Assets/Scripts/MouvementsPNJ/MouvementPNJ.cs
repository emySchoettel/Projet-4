using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouvementPNJ : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    private int i = 0; 
    private Vector3 nextVector; 

    private Tweener tweener; 
    private Animator anim; 

    public List<Chemin> chemins = new List<Chemin>(); 
    
    [System.Serializable]
    public class Chemin 
    {
        public GameObject gameObject; 
        [SerializeField]
        private Vector3 vector;
        public Helper.directions directionVers; 

        public Vector3 GetVector()
        {
            return vector; 
        }

        public void setVector(Vector3 newVector)
        {
            vector = newVector;
        }
    }

    private void Awake() 
    {
        foreach(Chemin chemin in chemins)
       {
            chemin.setVector(chemin.gameObject.transform.position);
       }
    }
  
    void Start()
    {
        anim = GetComponent<Animator>();
        transform.position = chemins[1].GetVector(); 
        for(int j = 0; j < chemins.Count; j++)
        {
            StartCoroutine(switchAnimation(chemins[j]));
        }
    }

    public IEnumerator switchAnimation(Chemin chemin)
    {
        yield return switchAnimationFunc(chemin.directionVers);  
        Debug.Log(chemin.directionVers.ToString());
        yield return Move(chemin);
    }

    public IEnumerator Move(Chemin chemin)
    {
        tweener = transform.DOMove(chemin.GetVector(), speed);
        tweener.SetEase(Ease.InOutQuad);
        while(tweener.IsPlaying())
        {
            yield return null; 
        }
        yield return null; 
    }

    public IEnumerator switchAnimationFunc(Helper.directions ladirection)
    {
        if(anim != null)
        {
             switch(ladirection)
            {
                case Helper.directions.droite:
                    anim.SetBool("right", true);
                    anim.SetBool("down", false);
                    anim.SetBool("left", false);
                    anim.SetBool("up", false);
                break;
                case Helper.directions.gauche:
                    anim.SetBool("left", true);
                    anim.SetBool("down", false);
                    anim.SetBool("right", false);
                    anim.SetBool("up", false);
                break;
                case Helper.directions.bas:
                    anim.SetBool("down", true);
                    anim.SetBool("right", false);
                    anim.SetBool("left", false);
                    anim.SetBool("up", false);
                break;
                case Helper.directions.haut:
                    anim.SetBool("up", true);
                    anim.SetBool("down", false);
                    anim.SetBool("left", false);
                    anim.SetBool("right", false);
                break;
            }
        }
        yield return new WaitForSeconds(10f);
    }
}
