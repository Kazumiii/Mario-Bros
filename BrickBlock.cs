using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock : MonoBehaviour {


   private SpriteRenderer sr;

    public Sprite explodedBlock;
    

    //time which is needed to switching sprites
    public float secBefreChangeSprite = 0.2f;



    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].point.y<transform.position.y)
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.rockSmash);

            sr.sprite = explodedBlock;
            DestroyObject(gameObject,secBefreChangeSprite);
        }
    }
}
