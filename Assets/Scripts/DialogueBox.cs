using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{

    public Transform posToSpawn = null; 
    public float letterPerSecond = 0.02f; 
    private Vector3 offset = new Vector3();
    public Sprite dialogSprite = null; 

    private List<string> texts = new List<string>();

    private float waitBetweenWords = 0f; 

    private GameObject dialogPrefab = null;
    private GameObject refDialogPrefab = null; 

    public GameObject currentDialogPrefab;
    Canvas canvas = null; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {

    }

    public bool Exist()
    {
        return refDialogPrefab;
    }

    public void Clear()
    {
        texts = new List<string>(); 
    }

    public void AddString(string txt)
    {
        texts.Add(txt);
    }

    public void AddString(List<string> txts)
    {
        foreach(string txt in txts)
        {
            texts.Add(txt);
        }
    }


}
