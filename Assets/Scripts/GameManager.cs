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
        GameObject bulle = Helper.addExpression(bulletarget, Expression.nomsExpressions.NoteMusique);
        StartCoroutine(nextExpression(bulletarget, Expression.nomsExpressions.Colere));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator nextExpression(GameObject bulleTarget, Expression.nomsExpressions exp)
    {
        yield return new WaitForSeconds(2f);
        Helper.addExpression(bulletarget, exp);
    }
}
