using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


    //SoundManger is using to controll and evoke music 
    public static SoundManager Instance = null;

    public AudioClip jump;
    public AudioClip getCoin;
    public AudioClip rockSmash;
    public AudioClip ManyDead;
 

    public AudioSource soundEffect;




    // Use this for initialization
    void Start()
    {


        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }


        AudioSource theSource = GetComponent<AudioSource>();
        soundEffect = theSource;
    }

    public void PlayOneShot(AudioClip clip)
    {
        soundEffect.PlayOneShot(clip);
    }
}
