using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{

    float currentTime = 0f;

    [SerializeField]
    float startingTime = 0f;

    public Text countDownText;
    private float timeTaken;

    void Start()
    {
        timeTaken = 0f;
        currentTime = startingTime;
        countDownText.text = "Time Remaining: 0.0";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameHasEnded == false)
        {
            currentTime -= 1 * Time.deltaTime;
            timeTaken += 1 * Time.deltaTime;
            countDownText.text = "Time Reamaining: " + currentTime.ToString("0.0");

            if (GameManager.coinsLeft <= 0)
            {
                FindObjectOfType<GameManager>().EndGame(timeTaken);
            }
            if (currentTime <= 0)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }    
    }
}
