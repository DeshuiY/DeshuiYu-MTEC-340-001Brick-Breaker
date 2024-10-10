using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _xLimit = 3.2f;
    [SerializeField] private KeyCode _leftKey;
    [SerializeField] private KeyCode _rightKey;
    
    private AudioSource _audioSource;
    

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_leftKey) && transform.position.x > - _xLimit)

        {
            transform.position += new Vector3(- _speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(_rightKey) && transform.position.x < _xLimit)

        {
            transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {
            if (_audioSource != null)
            {
                _audioSource.Play();
            }
        }
    }
}
