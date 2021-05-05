using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateursSceneManager : MonoBehaviour
{
    public bool LoadHubFirst = false;

    public Camera CreatorCamera;
    Camera cam;


    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
        //MainCamera =  GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {

        if (LoadHubFirst){
            SceneManager.LoadScene("HUB", LoadSceneMode.Single);
            LoadHubFirst = false;
            Destroy(this);
        }

    }
}
