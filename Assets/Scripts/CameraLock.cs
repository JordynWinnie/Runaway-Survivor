using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    private Vector3 startingPos = Vector3.zero;
    [SerializeField] private Transform playerPos;

    // Start is called before the first frame update
    private void Start()
    {
        startingPos = transform.position;
        StartCoroutine(UpdateCamPos());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator UpdateCamPos()
    {
        while (true)
        {
            transform.position = new Vector3(Mathf.Clamp(playerPos.position.x, -10f, 10f), Mathf.Clamp(playerPos.position.y + 30, 30f, 60f), playerPos.position.z - 30);
            yield return null;
        }
    }
}