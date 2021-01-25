using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class DieuxComportement : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spRenderer;
    public enum createurs
    {
        Emy,
        Gaetan
    }

    [SerializeField] private createurs Createurs;
    // Start is called before the first frame update
    void Start()
    {
        spRenderer = GetComponent<SpriteRenderer>(); 
        switch(Createurs)
        {
            case createurs.Emy: 
                sprites = Resources.LoadAll<Sprite>("Chibis/Emy_chibis");
            break; 

            case createurs.Gaetan:
                sprites = Resources.LoadAll<Sprite>("Chibis/Gaetan_chibis");
            break; 
        }
        if(spRenderer != null)
        {
            setSprite(Helper.emotionsCreateur.naturel);
        }
    }

    public void setSprite(Helper.emotionsCreateur position)
    {
        //TODO faire les émotions en corrélation avec les deux chibis
        switch(position)
        {
            case Helper.emotionsCreateur.naturel:
                spRenderer.sprite = sprites[1];
            break; 
            case Helper.emotionsCreateur.enerve:
                spRenderer.sprite = sprites[2];
            break; 
            case Helper.emotionsCreateur.triste:
                spRenderer.sprite = sprites[3];
            break; 
        }
    }
}
