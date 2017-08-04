using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.getCoin);

        IncreseTextUiScore();

        Destroy(gameObject);
    }

    void IncreseTextUiScore()
    {
        var textUIComponent = GameObject.Find("Score").GetComponent<Text>();
        int score = int.Parse(textUIComponent.text);

        score += 10;
        textUIComponent.text = score.ToString();
    }
}
