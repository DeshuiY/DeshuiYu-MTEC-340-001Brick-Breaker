using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] float _speed = 5.0f;

    [SerializeField] float _ylimit = 5.0f;

    [SerializeField] float _xlimit = 5.0f;

    private Vector2 _direction;
    // Start is called before the first frame update
    void Start()
    { 
        ResetBall();
    }

// Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            _speed * _direction.x,
            _speed * _direction.y,
            0.0f
            ) * Time.deltaTime;

        if (Mathf.Abs(transform.position.y) >= _ylimit)
        {
            _direction.y *= -1;
        }

        if (Mathf.Abs(transform.position.x) >= _xlimit)
        {
            ResetBall();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag("Paddle"))
            _direction.x *= -1;
    }

    void ResetBall()
    {
        transform.position = Vector3.zero;

        _direction = new Vector2(Random.value > 0.5f ? 1:-1, Random.value > 0.5f ?  1 : -1 );
        
    }
}
