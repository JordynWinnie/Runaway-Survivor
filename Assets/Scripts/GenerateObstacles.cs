﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform locationToGenerate;

    [SerializeField] private List<GameObject> obstacleList;
    [SerializeField] private List<GameObject> hardObstacleList;

    [SerializeField] private float positionXOffSet = 15f;
    [SerializeField] private float positionZOffSet = 50f;
    [SerializeField] private int generationUpperLimit = 32;
    [SerializeField] private int obstacleSpawnChance = 4;
    public bool generateAllowed = true;

    private void Start()
    {
        GenerateTerrain();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (generateAllowed)
        {
            GenerateTerrain();
            generateAllowed = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        generateAllowed = true;
    }

    public void GenerateTerrain()
    {
        foreach (Transform obstacle in transform)
        {
            Destroy(obstacle.gameObject);
        }
        print("Generating");
        var x = locationToGenerate.position.x - positionXOffSet;
        var y = 0;
        var z = locationToGenerate.position.z;
        for (int i = 0; i < generationUpperLimit + 1; i++)
        {
            if (Random.Range(0, 10) == 0)
            {
                continue;
            }
            for (int j = 0; j < 3; j++)
            {
                if (Random.Range(0, 50) == 0)
                {
                    var obstacle = Instantiate(hardObstacleList[Random.Range(0, hardObstacleList.Count)], new Vector3(x, y, z),
                    Quaternion.identity);
                    obstacle.transform.parent = transform;
                    break;
                }

                if (Random.Range(0, 2) == 0)
                {
                    var obstacle = Instantiate(obstacleList[Random.Range(0, obstacleList.Count)], new Vector3(x, y, z),
                    Quaternion.identity);
                    obstacle.transform.parent = transform;
                }

                x += positionXOffSet;
            }

            x = locationToGenerate.position.x - positionXOffSet;
            z += positionZOffSet;
        }
    }
}