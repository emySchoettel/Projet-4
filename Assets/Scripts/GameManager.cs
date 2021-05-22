using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject prefab; 
    public GameObject prefabHelper; 

    private GameObject helper; 

    public Button btnExitAttribut; 

    private void Awake() 
    {
        GameObject HelperGO = GameObject.Find("Helper");
        if(prefabHelper != null && HelperGO == null)
        {
            helper = Instantiate(prefabHelper, this.transform.position, Quaternion.identity);
        }
    }

    private void Start() 
    {
//       btnExitAttribut.onClick.AddListener(fermerUIAttribut);
    }

    void fermerUIAttribut()
    {
        gameObject.GetComponent<CanvasManager>().changeCanvas(CanvasManager.canvas.general);
        IsIntriggerAttribut.setCanOpenMenu(false);
    }
}
