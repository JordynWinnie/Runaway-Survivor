using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainPowerup : MonoBehaviour
{
    [SerializeField] private Transform[] spawnLocations;
    [SerializeField] private GameObject[] powerupList;

    // Start is called before the first frame update
    private void Start()
    {
        foreach (var location in spawnLocations)
        {
            if (Random.Range(0, 11) == 0)
            {
                var powerup = Instantiate(powerupList[0], location.position, Quaternion.identity);
                powerup.transform.parent = transform;
                break;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}