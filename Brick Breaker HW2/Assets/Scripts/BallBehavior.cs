using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] float _speed = 3.0f;
    [SerializeField] float _yLimit = 4.85f;
    [SerializeField] float _xLimit = 10f;
    [SerializeField] float _bottomLimit = -4.5f;

    private Vector2 _direction;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(_speed * _direction.x, _speed * _direction.y,0.0f) * Time.deltaTime;

    
        if (transform.position.y <= _bottomLimit)
        {
            ResetBall();
        }
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            _direction.y *= -1;
            
        }
        
        if (other.gameObject.CompareTag("Boundaries"))
        {
            _direction.y *= -1;
            
          
            
        }
        
        if (other.gameObject.CompareTag("SideWalls"))
        {
            _direction.x *= -1;
            
        }
        
    }

    void ResetBall()

    {
        transform.position = Vector3.zero;
        
        _direction = new Vector2(Random.value > 0.5f? 1 : -1, Random.value > 0.5f? 1 : -1);
    }

    public void ReverseXDirection()
    {
        _direction.x *= -1;
    }

    public void ReverseYDirection()
    {
        _direction.y *= -1;
    }



}
