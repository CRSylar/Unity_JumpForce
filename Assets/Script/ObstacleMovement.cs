using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 25;

    private PlayerController playerControllerScript;
    private float bound = -15;
    private bool check = true;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            // move the backgroud and the object
            if (!playerControllerScript.dashMode)
                transform.Translate(Vector3.left * Time.deltaTime * speed);
             // increase the speed if in dash mode
            else
                transform.Translate(Vector3.left * Time.deltaTime * speed * 3);
        }
        // handle score & destruction of obstacles
        if (transform.position.x < bound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            Debug.Log("Score : " + playerControllerScript.score);
        }
        if (transform.position.x < 0 && check)
        {
           if (playerControllerScript.dashMode)
                playerControllerScript.score += 3;
           else
                playerControllerScript.score += 1;
            check = false;
        }
    }
}
