using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEssai : MonoBehaviour
{
    public GameObject panel; 
    public Helper helper; 

    private void Start() 
    {
        helper.Fading(false, panel);
    }
}
