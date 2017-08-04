using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manny : MonoBehaviour {


    public float speed = 5;


    //it defines Manny

    private SpriteRenderer sr;
    private Rigidbody2D rg;
    private Animator anim;

    public bool facingRight = true;

    public float jumpingSpeed = 5;

    //checks if we hit in sth or not 
    private float RayCastLength = 0.005f;

    private float width;
    private float height;

    private float jumpButtonPressTime;
    private float maxjumpTime = 0.2f;

    bool isJumping = false;


    //I'm callingto function o make sure all will be creaed whenever i run my game 
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        width = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
        height = GetComponent<Collider2D>().bounds.extents.y + 0.2f;
    }
    //it's using when my use rigiBody2D in project to allows move our player
    public void FixedUpdate()
    {
        //it allows Manny move  horizontal what is required in 2D game
        float horz = Input.GetAxisRaw("Horizontal");


        Vector2 vect = rg.velocity;
        rg.velocity = new Vector2(horz * speed, vect.y);

        anim.SetFloat("Speed", Mathf.Abs(horz));

        if(horz>0 && !facingRight)
        {
            FlippManny();
        }
        else if(horz<0 && facingRight)
        {
            FlippManny();
        }


        float verMove = Input.GetAxis("Jump");
        if(IsOnGround() && isJumping==false)
        {
            if (verMove > 0)
                isJumping = true;
            

          
        }

        if(jumpButtonPressTime>maxjumpTime)
        {
            verMove = 0f;
        }
        if(isJumping && (jumpButtonPressTime<maxjumpTime))
        {
            rg.velocity = new Vector2(rg.velocity.x, jumpingSpeed);
        }

        //to fall
        if(verMove>=1f)
        {
            jumpButtonPressTime += Time.deltaTime;

        }
       else
        {
            isJumping = false;
            jumpButtonPressTime = 0f;
        }


    }

    public bool IsOnGround()
    {
        bool check1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - height), - Vector2.up, RayCastLength);

        bool check2 = Physics2D.Raycast(new Vector2(transform.position.x+(width-0.2f), transform.position.y - height), -Vector2.up, RayCastLength);

        bool check3 = Physics2D.Raycast(new Vector2(transform.position.x-(width-0.2f), transform.position.y - height), -Vector2.up, RayCastLength);


        if (check1 || check2 || check3)
            return true;


        return false;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }



    //Methoda allwos turnning left/right
    private void FlippManny()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
	// Update is called once per frame
	void Update () {
		
	}
}
