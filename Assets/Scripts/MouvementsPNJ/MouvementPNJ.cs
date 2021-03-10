using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementPNJ : MonoBehaviour
{
    public List<GameObject> Paths = new List<GameObject>();

    [SerializeField]
    private List<Vector3> coordoneesPaths = new List<Vector3>();  

    [SerializeField]
    private float speed = 1;

    private float t; 

  
    void Start()
    {
        setCoordonneesPath();
    }

    private void Update() 
    {
        t += Time.deltaTime * speed; 

        transform.position = Vector3.Lerp(coordoneesPaths[0], coordoneesPaths[1], Easing.Quadratic.InOut(t));

        // if(t >= 1)
        // {
        //     var b = coordoneesPaths[1];
        //     var a = coordoneesPaths[0]; 

        //     b = coordoneesPaths[0]; 
        //     a = coordoneesPaths[1];

        //     t = 0;
        // }
    }

    private Vector3 CustomLerp(Vector3 a, Vector3 b, float t)
    {
        return a * (1 - t) + b * t;    
    }

    #region set

    void setCoordonneesPath()
    {
        foreach(GameObject game in Paths)
        {
            coordoneesPaths.Add(game.transform.position);
        }
    }

    #endregion
}
