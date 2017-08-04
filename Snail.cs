using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour {


    public float speed=2f;

    //pointing out direct which snail should takes 
    Vector2 direction =Vector2.right ;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = direction*speed;


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //here we have negative value to trun snail in opposite direction
        transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);

        direction = new Vector2(-1 * direction.x, direction.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name=="Manny")
        {
            //if many jump on snail
            if(collision.contacts[0].point.y>transform.position.y)
            {
                GetComponent<Animator>().SetTrigger("Dead");
                GetComponent<Collider2D>().enabled = false;
                direction = new Vector2(direction.x, -1);
                Destroy(gameObject, 3);
            }
            else
            {
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.ManyDead);
                Destroy(collision.gameObject, 3f);
            }

        }
    }

}
