using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class teleport : MonoBehaviour
{

    public GameObject Destination;
    public Transform player;
    public bool CanTp = true;
    public Image img;
    public int FadTime = 1;
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Player")
        {
            StartCoroutine(FadeImage(true));

            if (CanTp)
            {
                player.transform.position = Destination.transform.position;
            }
            Destination.GetComponentInChildren<teleport>().CanTp = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            CanTp = true;
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
