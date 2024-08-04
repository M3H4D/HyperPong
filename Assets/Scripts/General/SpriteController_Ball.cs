using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SpriteController_Ball : MonoBehaviour
{
    static public int bSpriteIndex;
    public Sprite[] sprites;
    public AudioClip[] clips;
    
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = sprites[bSpriteIndex];
        this.GetComponent<AudioSource>().clip = clips[bSpriteIndex];
        if (bSpriteIndex == 3)
        {
            this.GetComponent<Animator>().enabled = true;
            this.GetComponent<Animator>().SetInteger("SpriteIndex", bSpriteIndex);
        }
        else
        {
            this.GetComponent<Animator>().enabled = false;
        }
        
    }
}
