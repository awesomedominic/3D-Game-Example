using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingWithRollABall : MonoBehaviour
{
    private Rigidbody _playerRb;
    public float JumpForce = 10f;
    public float GravityModifier = 1f;
    public bool isOnGround = true;
    public float speed = 10.5f;
    private float _horizontalInput;
    private float _forwardInput;

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_horizontalInput, 0.0f, _forwardInput);

        _playerRb.AddForce(movement * speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
         _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            _playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnGround = false;     
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
