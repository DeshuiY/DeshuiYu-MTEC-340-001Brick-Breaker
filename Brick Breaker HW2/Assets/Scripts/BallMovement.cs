using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed= 5f;
    private Vector2 direction = new Vector2(1, 1).normalized;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction*speed*Time.deltaTime);

        if (transform.position.x >= 3.4f || transform.position.x <= -3.4f)
        {
            direction.x = -direction.x;
            
        }
        if(transform.position.y >= 4.8f)
        {
            direction.y = -direction.y;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.name == "Paddle" || collision.gameObject.CompareTag("Brick"))

        {
            direction.y = -direction.y;
        }
        
        if (collision.gameObject.name == "TopPaddle" || collision.gameObject.CompareTag("Brick"))

        {
            direction.y = -direction.y;
        }
            
    }
}
