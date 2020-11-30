using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
* Script that manages all of the game.
*/
public class GameManager : MonoBehaviour
{
    /*
    * Object Tags:
    */
    public static readonly string BOTTOM_BORDER = "BottomBorder";

    public static readonly string BRICK = "Brick";

    public static readonly string HARDER_BRICK = "HarderBrick";

    public static readonly string LIFE_ADDER = "LifeAdder";

    //
    public int lives;

    public int score;

    public Text livesText;

    public Text scoreText;

    public GameObject gameOverPanel;

    public GameObject gameFinishPanel;

    public bool gameOver;

    public int bricksCounter;

    private int level;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        if (level != 0 && level != 1)
        {
            LoadData();
        }

        int numOfBricks = GameObject.FindGameObjectsWithTag(BRICK).Length;
        int numOfHarderBricks =
            GameObject.FindGameObjectsWithTag(HARDER_BRICK).Length;
        bricksCounter = numOfBricks + numOfHarderBricks;

        DisplayLives();
        DisplayScore();
    }

    /**
    *   Method that retrieves data from PlayerPrefs
    */
    public void LoadData()
    {
        score = PlayerPrefs.GetInt("Score", score);
        lives = PlayerPrefs.GetInt("Lives", lives);
    }

    /**
    *   Method that save data to PlayerPrefs
    */
    public void SaveData()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Lives", lives);
    }

    /**
    *   Display lives on canvas
    */
    private void DisplayLives()
    {
        livesText.text = "Lives: " + lives;
    }

    /**
    *   Display score on canvas
    */
    private void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

    /**
    *   Decrease lives by 1
    */
    public void DecreaseLives()
    {
        lives--;
        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }
        DisplayLives();
    }

    /**
    *   Increase lives by 1
    */
    public void IncreaseLives()
    {
        lives++;
        DisplayLives();
    }

    /**
    *   Update score with given points
    */
    public void UpdateScore(int points)
    {
        score += points;

        DisplayScore();
    }

    /**
    *   Update bricks when breaking them, and check if there is any bricks left
    */
    public void BricksUpdate()
    {
        bricksCounter--;
        if (bricksCounter <= 0)
        {
            gameOver = true;
            SaveData();
            NextLevel();
        }
    }

    /**
    *   Initiate Game Over Panel
    */
    private void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    /**
    *   Returns to level 1
    */
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    /**
    *   Returns to main menu
    */
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    /**
    *   if on level 4, display game finished panel. go to next level otherwise.
    */
    public void NextLevel()
    {
        if (++level == 5)
        {
            gameFinishPanel.SetActive(true);
            gameOver = true;
            return;
        }
        SceneManager.LoadScene (level);
    }
}
