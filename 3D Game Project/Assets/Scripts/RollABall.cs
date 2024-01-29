using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollABall : MonoBehaviour
{

    public float speed = 10.5f;

    private float _horizontalInput;
    private float _forwardInput;

    

    private Rigidbody _playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_horizontalInput, 0.0f, _forwardInput);

        _playerRigidbody.AddForce(movement * speed);
    }

    
}
