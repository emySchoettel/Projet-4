using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadWorld : MonoBehaviour
{
    public string World;
    private Scene m_Scene;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(World, LoadSceneMode.Single);
        }
    }

}
