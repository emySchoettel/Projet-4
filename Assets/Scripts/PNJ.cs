using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            GetComponent<Animator>().Rebind();
        }
    }
}
