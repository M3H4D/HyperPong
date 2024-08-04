using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballSpeed;
    public int xDirection = 0;
    public float yDirection = 1;

    public MainController main;

    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ballReset();
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(xDirection * ballSpeed * Time.deltaTime, yDirection * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Paddle"))
        { 
            xDirection *= -1;
            yDirection = (transform.position.y - collision.transform.position.y) * 1.65f;
            this.GetComponent<AudioSource>().Play();

            if (MainController.difficulty == 0)
            {
                ballSpeed += 0.3f;
            }
            if (MainController.difficulty == 1)
            {
                ballSpeed += 0.5f;
            }
            if (MainController.difficulty == 2)
            {
                ballSpeed += 0.7f;
            }

        }
        else if (collision.transform.CompareTag("Top") || collision.transform.CompareTag("Bottom"))
        {
            yDirection *= -1;
            this.GetComponent<AudioSource>().Play();
        }
        else if (collision.transform.CompareTag("Left"))
        {
            //Restart
            main.incrementP2Score();
            ballReset();
        }
        else if (collision.transform.CompareTag("Right"))
        {
            //Restart
            main.incrementP1Score();
            
            ballReset();
        }
        else if (collision.transform.CompareTag("Wall"))
        {
            xDirection *= -1;
            yDirection = (transform.position.y - collision.transform.position.y) * 1.65f;
        }
    }

    private void ballReset()
    {
        //transform.position = Vector2.zero;
        transform.position = new Vector2(0, Random.Range(-3, 3));

        while (xDirection == 0)
        {
            xDirection = (int)Random.Range(-1, 2);
        }

        yDirection = Random.Range(-1.0f, 1.0f);

        //default speed
        if (MainController.difficulty == 0)
        {
            ballSpeed = 5;
        }
        else if (MainController.difficulty == 1)
        {
            ballSpeed = 6;
        }
        else if (MainController.difficulty == 2)
        {
            ballSpeed = 7;
        }

    }


}
