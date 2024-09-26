using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    
    
        public float speed = 10f;
        public float boundaryX = 7.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontal, 0f, 0f)*speed*Time.deltaTime;
        transform.position += movement;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
