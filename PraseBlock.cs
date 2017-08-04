using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PraseBlock : MonoBehaviour {

    //Animations effects  when praise block is being hited
    public AnimationCurve anim;


    //how many coins are inside block
    public int howManyCoins = 5;




    //tack collision
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //first statement checks if position of my player is below position of block (second statment)
        //if yes then we can hit block and get money
        if(collision.contacts[0].point.y<transform.position.y)
        {
            //Crete Corutine to pass things
            StartCoroutine(RunAnimation());
        }

        if(howManyCoins>0)
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.getCoin);
            IncreseTextUiScore();
            howManyCoins--;

        }
    }

    //Corutine method must return IEnumarator
IEnumerator RunAnimation()
    {

        //here we define animations


        //first value allows praiseBlock back to  startin position
        Vector2 startPoition = transform.position;

            for(float x=0;x<anim.keys[anim.length-1].time;x+=Time.deltaTime)
        {
            transform.position = new Vector2(startPoition.x, startPoition.y + anim.Evaluate(x));

            //now we yield back to continue looping

            yield return null;
        }
    }

    void IncreseTextUiScore()
    {
        var textUIComponent = GameObject.Find("Score").GetComponent<Text>();
        int score = int.Parse(textUIComponent.text);

        score += 10;
        textUIComponent.text = score.ToString();
    }
}
