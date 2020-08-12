using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public enum PlayerPositionState { Right, Left, Middle };

    public PlayerPositionState playerPosition;
    [SerializeField] float jumpSpeed = 10.0f;
    [SerializeField] float gravity = 20.0f;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerPosition = PlayerPositionState.Middle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (playerPosition)
        {
            case PlayerPositionState.Right:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    playerPosition = PlayerPositionState.Middle;
                    transform.Translate(Vector3.left * 5f);
                }
                break;
            case PlayerPositionState.Left:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    playerPosition = PlayerPositionState.Middle;
                    transform.Translate(Vector3.right * 5f);
                }
                break;
            case PlayerPositionState.Middle:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    //Going Left:
                    playerPosition = PlayerPositionState.Left;
                    transform.Translate(Vector3.left * 5f);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    //GOing right:
                    playerPosition = PlayerPositionState.Right;
                    transform.Translate(Vector3.right * 5f);
                }
                break;
            default:
                break;
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
