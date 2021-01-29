using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaceNameFad : MonoBehaviour
{
     // the image you want to fade, assign in inspector
    public Image img;
    public int FadTime = 1;
    void OnTriggerEnter(Collider Player)
    {
        if (Player.tag == "Player"){
            StartCoroutine(FadeImage(true));
        }
    }
 
    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            for (float i = FadTime; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        else
        {
            for (float i = FadTime; i <= 1; i += Time.deltaTime)
            {
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
