using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public float OutOfBounds = -10f;
    private Vector3 _startingPosition;
    private Vector3 _checkpointPosition;
    private bool _isAtCheckpoint = false;

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < OutOfBounds)
        {
            if(_isAtCheckpoint)
            {
                transform.position = _checkpointPosition;
            }
            else
            {
                transform.position = _startingPosition;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = _startingPosition;

             if(_isAtCheckpoint)
            {
                transform.position = _checkpointPosition;
            }
            else
            {
                transform.position = _startingPosition;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            _isAtCheckpoint = true;
            _checkpointPosition = other.gameObject.transform.position;
        }
    }
}
