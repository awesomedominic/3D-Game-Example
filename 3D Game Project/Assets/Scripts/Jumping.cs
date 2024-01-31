using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private Rigidbody _playerRb;
    public float JumpForce = 10f;
    public float GravityModifier = 1f;
    public bool isOnGround = true;
    public float turnSpeed = 20f;
    public float moveSpeed = 1f;
    Vector3 m_Movement;
    Rigidbody m_Rigidbody;
    Quaternion m_Rotation = Quaternion.identity;

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);

        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * moveSpeed * Time.deltaTime);
        m_Rigidbody.MoveRotation (m_Rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
        m_Rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
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