using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float damageToDeal = 0.5f;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        GameManager.playerSpeed -= 5;
        GameManager.instance.AddAttackerScore(-damageToDeal);
        //print("Player got hit!");
        Destroy(gameObject);
    }
}