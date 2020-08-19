using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;

    private void Start()
    {
        //StartCoroutine(UpdateCamPos());
    }

    private void Update()
    {
        print("Hello");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            transform.localScale = new Vector3(1, 0.5f, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position = new Vector3(playerPosition.position.x, playerPosition.position.y, playerPosition.position.z - 15);
    }
}