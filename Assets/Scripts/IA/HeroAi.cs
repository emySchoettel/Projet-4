using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAi : MonoBehaviour
{
    public bool IsFolow = true;
    public float speed = 2;
    public int PlayerDistance = 1;
    public Transform Player;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.position);
        if ((transform.position - Player.position).magnitude > PlayerDistance && IsFolow ){
            transform.Translate(0.0f,0.0f, speed * Time.deltaTime);
                    transform.Rotate( 0, 0, 0 );

        }

        if ((transform.position - Player.position).magnitude > 10  && IsFolow){
            transform.position = Player.position;
        }

        if (Input.GetKeyDown(KeyCode.D) && IsFolow == true)
        {
            anim.SetBool("HeroWalkRight", true);
            anim.SetBool("HeroWalkLeft", false);
            anim.SetBool("HeroWalkUp", false);
            anim.SetBool("HeroWalkDown", false);
        }

        if (Input.GetKeyDown(KeyCode.Q) && IsFolow == true)
        {
            anim.SetBool("HeroWalkRight", false);
            anim.SetBool("HeroWalkLeft", true);
            anim.SetBool("HeroWalkUp", false);
            anim.SetBool("HeroWalkDown", false);
        }
        if (Input.GetKeyDown(KeyCode.Z) && IsFolow == true)
        {
            anim.SetBool("HeroWalkRight", false);
            anim.SetBool("HeroWalkLeft", false);
            anim.SetBool("HeroWalkUp", true);
            anim.SetBool("HeroWalkDown", false);
        }
        if (Input.GetKeyDown(KeyCode.S) && IsFolow == true)
        {
            anim.SetBool("HeroWalkRight", false);
            anim.SetBool("HeroWalkLeft", false);
            anim.SetBool("HeroWalkUp", false);
            anim.SetBool("HeroWalkDown", true);
        }
        if (IsFolow == false)
        {
            anim.SetBool("HeroWalkRight", false);
            anim.SetBool("HeroWalkLeft", false);
            anim.SetBool("HeroWalkUp", false);
            anim.SetBool("HeroWalkDown", false);
        }


    }
    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }
}
