using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
         
            float xDistance = Mathf.Abs(transform.position.x - collision.transform.position.x);
            float yDistance = Mathf.Abs(transform.position.y - collision.transform.position.y);
            
            if (xDistance > yDistance)
            {
                collision.gameObject.GetComponent<BallBehavior>().ReverseXDirection();
            }
            else
            {
                collision.gameObject.GetComponent<BallBehavior>().ReverseYDirection();
            }
           
            Destroy(gameObject);
            
            if (GameBehavior.Instance != null)
            {
                GameBehavior.Instance.Score += 1;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
