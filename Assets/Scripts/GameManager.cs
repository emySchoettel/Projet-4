using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject prefab; 
    public GameObject bulletarget; 
    // Start is called before the first frame update
    void Start()
    {
        Helper.addExpression(bulletarget, Expression.nomsExpressions.Coeur);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
