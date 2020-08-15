using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.AddAttackerScore(0.5f);
        Destroy(gameObject);
    }
}