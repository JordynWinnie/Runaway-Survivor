using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        var otherTrans = other.transform;
        print(otherTrans.position.z);
        other.transform.position = new Vector3(otherTrans.position.x, otherTrans.position.y, -300);
    }
  
}
