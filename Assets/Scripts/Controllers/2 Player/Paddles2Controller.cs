using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddles2Controller : MonoBehaviour
{

    public GameObject paddle1;
    public GameObject paddle2;



    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.touchCount == 1)
        {
            
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            

            if(touchPosition.x < 0)
            {
                paddle1.transform.position = new Vector2(paddle1.transform.position.x , touchPosition.y);
            }
            else if(touchPosition.x > 0)
            {
                paddle2.transform.position = new Vector2(paddle2.transform.position.x, touchPosition.y);
            }


        }
        else if(Input.touchCount > 1)
        {
            Vector3 touchPosition1 = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector3 touchPosition2 = Camera.main.ScreenToWorldPoint(Input.GetTouch(1).position);

            if (touchPosition1.x < 0)
            {
                paddle1.transform.position = new Vector2(paddle1.transform.position.x, touchPosition1.y);
            }
            else if (touchPosition1.x > 0)
            {
                paddle2.transform.position = new Vector2(paddle2.transform.position.x, touchPosition1.y);
            }
            if (touchPosition2.x < 0)
            {
                paddle1.transform.position = new Vector2(paddle1.transform.position.x, touchPosition2.y);
            }
            else if (touchPosition2.x > 0)
            {
                paddle2.transform.position = new Vector2(paddle2.transform.position.x, touchPosition2.y);
            }
        }
    }
}
