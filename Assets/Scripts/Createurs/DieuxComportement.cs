using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class DieuxComportement : MonoBehaviour
{
    public Dictionary<emotionsCreateur, Sprite> sprites;

    [SerializeField] private createurs Createurs;
    //public Sprite[] sprites;
    private SpriteRenderer spRenderer;
    public enum createurs
    {
        Emy,
        Gaetan
    }
    public enum emotionsCreateur
    {
        naturel,
        enerve,
        triste,
        espiegle,
        rire,
        gene

    }

    private void Awake() 
    {
        spRenderer = gameObject.GetComponent<SpriteRenderer>();
        sprites = new Dictionary<emotionsCreateur, Sprite>();
        Sprite[] listofSprites = new Sprite[6];
        switch(Createurs)
        {
            case createurs.Emy: 
                listofSprites = Resources.LoadAll<Sprite>("Chibis/Emy_chibis");
            break; 

            case createurs.Gaetan:
                listofSprites = Resources.LoadAll<Sprite>("Chibis/Gaetan_chibis");
            break; 
        }
        AddToDic(listofSprites); 
    }
    private void AddToDic(Sprite[] sps)
    {
        sprites.Add(emotionsCreateur.naturel, sps[0]);
        sprites.Add(emotionsCreateur.enerve, sps[1]);
        sprites.Add(emotionsCreateur.triste, sps[2]);
        sprites.Add(emotionsCreateur.espiegle, sps[3]);
        sprites.Add(emotionsCreateur.rire, sps[4]);
        sprites.Add(emotionsCreateur.gene, sps[5]);
    }

    public void changeSprite(emotionsCreateur emotion)
    {
        if(sprites[emotion] != null)
        {
            spRenderer.sprite = sprites[emotion];
        }
    } 

    public createurs getCreateurType()
    {
        return Createurs;
    }
}
