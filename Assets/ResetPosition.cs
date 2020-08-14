using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public bool canTeleport = true;

    private void OnCollisionEnter(Collision other)
    {
        other.transform.Translate(new Vector3(0, 0, -900), Space.World);
    }
}