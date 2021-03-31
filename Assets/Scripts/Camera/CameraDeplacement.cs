using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDeplacement : MonoBehaviour
{

    public Transform[] positions; 
    [SerializeField]
    private bool[] verifPositions; 

    public GameObject mainCamera; 
    public int i = 0; 

    private void FixedUpdate() 
    {
        if(verifPositions[i])    
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, positions[i].transform.position, 0.1f);
        }
    }


    public void setPosition(int i, bool choix)
    {
        verifPositions[i] = choix;
    }

}
