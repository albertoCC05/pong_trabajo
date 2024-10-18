using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Movment variables

    private float speed = 12f;
    private float verticalInput;
    private float bounds = 3.17f;
    [SerializeField] private bool isPlayer1;

    private void Update()
    {

        Movment();
        
    }

   // Movment of the player, first I detect if you are playing with player 1 or 2, with the bool variable isPlayer1
   //If its true you move with ws and if it is false with the direction keys,
   

    private void Movment()
    {
        
        if (isPlayer1)
        {
            verticalInput = Input.GetAxis("Vertical");

            if (verticalInput > 0.1f || verticalInput < -0.1f)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime * verticalInput);
            }
        }
        if (!isPlayer1)
        {
            verticalInput = Input.GetAxis("Vertical2");

            if (verticalInput > 0.1f || verticalInput < -0.1f)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime * verticalInput);
            }
        }
           
      // Seting the bounds for the players           

        if (transform.position.y >= bounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.03f, transform.position.z);
        }
        if (transform.position.y <= -bounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.03f, transform.position.z);
        }









    }
}
