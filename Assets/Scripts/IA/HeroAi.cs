using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAi : MonoBehaviour
{
    public bool IsFolow = true;
    public float speed = 2;
    public int PlayerDistance = 1;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.position);
        if ((transform.position - Player.position).magnitude > PlayerDistance && IsFolow ){
            transform.Translate(0.0f,0.0f, speed * Time.deltaTime);
                    transform.Rotate( 0, 0, 0 );

        }
    }
    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }
}
