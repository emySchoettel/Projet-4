using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateursSceneManager : MonoBehaviour
{
    public bool LoadHubFirst = false;
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (LoadHubFirst){
            SceneManager.LoadScene("HUB", LoadSceneMode.Additive);
            LoadHubFirst = false;
        }
    }
}
