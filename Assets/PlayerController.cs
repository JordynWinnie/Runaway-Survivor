using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;



    [SerializeField] float jumpSpeed = 10.0f;
    [SerializeField] float gravity = 20.0f;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.left * 5f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right * 5f);
        }

        //print(rb.velocity);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    
    private void OnCollisionEnter()
    {
        isGrounded = true;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward);
    }
}
