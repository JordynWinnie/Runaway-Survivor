using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    private Vector3 startingPos = Vector3.zero;

    // Start is called before the first frame update
    private void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, startingPos.y, transform.position.z);
    }
}