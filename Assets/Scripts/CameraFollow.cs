using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothing = 5f;
    [SerializeField]
    private float zMaxDistance = 1;
    [SerializeField]


    private float baseZ;
    Vector3 offset;


    void Start()
    {
        baseZ = transform.position.z;
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 targetCamPos = target.position + offset;
        if (targetCamPos.z < zMaxDistance)
        {
            targetCamPos.z = zMaxDistance;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }

    }
    private void OnTriggerEnter(Collider coll)//NE MARCHER PAS JSP PK
    {
        Debug.Log("COLID 19");
        offset.z = baseZ;
    }



}
