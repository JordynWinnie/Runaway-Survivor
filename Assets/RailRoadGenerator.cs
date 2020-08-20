using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailRoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject railroad;

    // Start is called before the first frame update
    private void Start()
    {
        var x = transform.position.x - 15;
        var y = 1;
        var z = transform.position.z;
        for (int i = 0; i < 33; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Instantiate(railroad, new Vector3(x, y, z), Quaternion.identity).transform.parent = transform;
                x += 15;
            }

            x = transform.position.x - 15;
            z += 50;
        }
    }
}