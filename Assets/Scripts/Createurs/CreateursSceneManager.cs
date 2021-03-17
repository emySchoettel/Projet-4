using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateursSceneManager : MonoBehaviour
{
    public bool LoadHubFirst = false;
    public bool SwitchCam = false;
    public Camera MainCamera;

    public Camera CreatorCamera;
    Camera cam;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        MainCamera =  GameObject.Find("MainCamera").GetComponent<Camera>();
        cam = GameObject.Find("myObject").GetComponent<Camera>();
    }

    void Update()
    {
        MainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        if (LoadHubFirst){
            SceneManager.LoadScene("HUB", LoadSceneMode.Additive);
            LoadHubFirst = false;
        }

        if (SwitchCam){
            //Enable the second Camera
            CreatorCamera.enabled = true;
            //The Main first Camera is disabled
            MainCamera.enabled = false;
        }
        if (!SwitchCam){
            //Enable the second Camera
            CreatorCamera.enabled = false;
            //The Main first Camera is disabled
            MainCamera.enabled = true;
        }



    }
}
