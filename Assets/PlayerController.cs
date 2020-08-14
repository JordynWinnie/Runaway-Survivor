using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public enum PlayerPositionState { Right, Left, Middle };

    public float distanceBetweenLanes = 15f;
    public PlayerPositionState playerPosition;
    [SerializeField] private float jumpSpeed = 10.0f;
    [SerializeField] private float runningSpeed = 10f;
    public bool isGrounded = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerPosition = PlayerPositionState.Middle;
    }

    // Update is called once per frame
    private void Update()
    {
        switch (playerPosition)
        {
            case PlayerPositionState.Right:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    playerPosition = PlayerPositionState.Middle;
                    transform.Translate(Vector3.left * distanceBetweenLanes);
                }
                break;

            case PlayerPositionState.Left:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    playerPosition = PlayerPositionState.Middle;
                    transform.Translate(Vector3.right * distanceBetweenLanes);
                }
                break;

            case PlayerPositionState.Middle:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    //Going Left:
                    playerPosition = PlayerPositionState.Left;
                    transform.Translate(Vector3.left * distanceBetweenLanes);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    //GOing right:
                    playerPosition = PlayerPositionState.Right;
                    transform.Translate(Vector3.right * distanceBetweenLanes);
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isGrounded)
        {
            rb.AddForce(Vector3.down * jumpSpeed * 5f, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            transform.localScale = new Vector3(1, 0.75f, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        rb.AddForce(Vector3.down * Time.deltaTime * jumpSpeed * 2, ForceMode.Impulse);
    }

    private void OnCollisionEnter()
    {
        isGrounded = true;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * runningSpeed * Time.deltaTime);
    }
}