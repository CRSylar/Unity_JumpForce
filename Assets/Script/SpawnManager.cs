using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private float startDelay = 4.0f;

    private Vector3 spawnPos = new Vector3(35, 0, 0);
    public GameObject[] obstacles;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", startDelay, Random.Range(2, 5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacles()
    {
        if (!playerControllerScript.gameOver)
        {
            int obstacleIdx = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[obstacleIdx], spawnPos, obstacles[obstacleIdx].transform.rotation);
        }
    }
}
