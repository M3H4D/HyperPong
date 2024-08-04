using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController_Paddles : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;

    static public int p1SpriteIndex;
    static public int p2SpriteIndex;
    public Sprite[] sprites;


    void Start()
    {
        p1.GetComponent<SpriteRenderer>().sprite = sprites[p1SpriteIndex];
        p2.GetComponent<SpriteRenderer>().sprite = sprites[p2SpriteIndex];
    }
}
