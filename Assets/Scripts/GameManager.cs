using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text text;
    public Text gameOverText;
    public Text highscoreText;
    public Text timeTakenText;
    public Text coinsLeftText;
    public GameObject button;

    private float highscore;
    public static int coinsLeft;
    public static bool gameHasEnded;

    [SerializeField]
    private int coinsToCollect = 10;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        coinsLeft = coinsToCollect;
        coinsLeftText.text = "Coins left: " + coinsLeft.ToString();
        gameHasEnded = false;
        gameOverText.text = "";
        highscoreText.text = "";
        timeTakenText.text = "";
        button.SetActive(false);
    }

    void Update()
    {
        coinsLeftText.text = "Coins left: " + coinsLeft.ToString();
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;

            gameOverText.text = "Game over!";
            timeTakenText.text = "try again.";
            button.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void EndGame(float timeTaken)
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;

            timeTakenText.text = "Time: " + timeTaken.ToString("0.0");
            highscore = PlayerPrefs.GetFloat("Highscore", 1000f);
            if (timeTaken < highscore)
            {
                PlayerPrefs.SetFloat("Highscore", timeTaken);
                highscoreText.text = "Highscore: " + timeTaken.ToString("0.0");
            } else
            {
                highscoreText.text = "Highscore: " + highscore.ToString("0.0");
            }  

            gameOverText.text = "Good job!";
            button.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
