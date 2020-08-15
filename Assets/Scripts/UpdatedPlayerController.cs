using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedPlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    private CharacterController characterController;
    public bool isGround;
    private Vector3 moveDirection = Vector3.zero;

    public enum PlayerPositionState { Right, Left, Middle };

    public PlayerPositionState playerPosition;

    // Start is called before the first frame update
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection.z = speed;
            isGround = characterController.isGrounded;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        var currentPos = transform.position;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("hello");
        }

        switch (playerPosition)
        {
            case PlayerPositionState.Right:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    playerPosition = PlayerPositionState.Middle;
                }
                break;

            case PlayerPositionState.Left:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    playerPosition = PlayerPositionState.Middle;
                }
                break;

            case PlayerPositionState.Middle:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    //Going Left:
                    playerPosition = PlayerPositionState.Left;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    //GOing right:
                    playerPosition = PlayerPositionState.Right;
                }
                break;

            default:
                break;
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}