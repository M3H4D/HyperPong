using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_AI : MonoBehaviour
{
    // Start is called before the first frame update

    public float paddleSpeed;

    public MainController main;
    public BallController ball;

    Rigidbody2D rb;

    public float height;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        height =  GetComponent<SpriteRenderer>().bounds.size.y;
        paddleSpeed = 3;
        if (MainController.difficulty == 0)
        {
            paddleSpeed = 1;
        }
        else if (MainController.difficulty == 1)
        {
            paddleSpeed = 1.5f;
        }
        else if (MainController.difficulty == 2)
        {
            paddleSpeed = 2;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.position.y + 1.3 < ball.transform.position.y)
        {
            rb.MovePosition(rb.position + new Vector2(0, paddleSpeed * Time.deltaTime));
        }
        else if (rb.position.y - 1.3 > ball.transform.position.y)
        {
            rb.MovePosition(rb.position - new Vector2(0, paddleSpeed * Time.deltaTime));
        }
        
    }


}
