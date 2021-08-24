using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform startingPoint;
    public float lerpSpeed;


    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        playerControllerScript.gameOver = true;
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerControllerScript.transform.position;
        Vector3 endPos = startingPoint.position;

        float journeyLenght = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLenght;

        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

       while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLenght;

            playerControllerScript.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);

            yield return null;
        }

        playerControllerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        playerControllerScript.gameOver = false;
    }
}