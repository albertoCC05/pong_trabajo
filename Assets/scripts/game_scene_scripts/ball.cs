using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ball : MonoBehaviour
{
  //Script reference
    private GameManager gameManager;

  //rigid body of the ball and movment variables

    private Rigidbody2D ballRb;
    [SerializeField] private float initialVelocity = 4;
    private float velocityMultiplyer = 1.1f;
    


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ballRb = GetComponent<Rigidbody2D>();

        //At the start of the game I call the function for launch the ball in a randmoly direction

        StartCoroutine(Launch());
        
    }
   

    //Detection if the ball touches one of the scrore lines

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("score"))
        {
            gameManager.AddPointsTo2();
            ballRb.velocity = Vector2.zero;
            StartCoroutine(Launch());
        }
        if (other.gameObject.CompareTag("score2"))
        {
            gameManager.AddPointsTo1();
            ballRb.velocity = Vector2.zero;
            StartCoroutine(Launch());
        }
    }

    // When the ball collides with one of each paddles his speed is increased

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("padle"))
        {
            ballRb.velocity = ballRb.velocity * velocityMultiplyer;
        }
    }


   //Function for launch the ball in a randomly direction, first I put the ball on (0,0,0)
   //Then I calculate a random direction and then the ball is launched

    private IEnumerator Launch()
    {
        transform.position = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(4);

        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;

    }

  
}
