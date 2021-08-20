using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public float speed = 25;
    private float bound = -15;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x < bound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
