using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementPNJ : MonoBehaviour
{
    public List<GameObject> Paths = new List<GameObject>(); 
    private Rigidbody rigidbody; 
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
        StartCoroutine(mouvement());
    }

    public IEnumerator mouvement()
    {
        foreach(GameObject path in Paths)
        {
            for(float i = gameObject.transform.position.z; i < path.transform.position.z; i++)
            {
                //rigidbody.velocity = new Vector3()
            }
        }
        
        yield return null;
    }
}
