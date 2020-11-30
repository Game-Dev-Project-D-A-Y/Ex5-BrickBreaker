using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    public  int lives;

    public  int score;

    public Text livesText;

    public Text scoreText;

    public GameObject gameOverPanel;

    public bool gameOver;

    public int bricksCounter;
    
    private int level;


 
    // Start is called before the first frame update
    void Start()
    {
        
        level= SceneManager.GetActiveScene().buildIndex;
        if(level != 0 && level != 1 )
        {
            LoadData();
        }
    

        bricksCounter = GameObject.FindGameObjectsWithTag("Brick").Length + GameObject.FindGameObjectsWithTag("HarderBrick").Length;
        DisplayLives();
        DisplayScore();
    }

    public void LoadData()
    {
        score = PlayerPrefs.GetInt("Score",score);
        lives = PlayerPrefs.GetInt("Lives",lives);
    }

     public void SaveData()
    {
     PlayerPrefs.SetInt("Score",score);   
     PlayerPrefs.SetInt("Lives",lives);   
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void DisplayLives()
    {
        livesText.text = "Lives: " + lives;
    }

    private void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void DecreaseLives()
    {
        lives--;
    if(lives<=0)
    {
        lives = 0;
        GameOver();
    }
        // check if there is no more lives
        DisplayLives();
    }

    public void IncreaseLives()
    {
        lives++;
        DisplayLives();
    }

    public void UpdateScore(int points)
    {
        score += points;

        DisplayScore();
    }

    public void BricksUpdate()
    {
        bricksCounter--;
        if(bricksCounter <= 0){
            gameOver = true; 
            SaveData();
            NextLevel();
        }
    }
    private void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        Debug.Log("PlayAgain");
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Debug.Log("Exit");
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        if(++level==5)
        {
            return;
        }
        SceneManager.LoadScene(level);
    }
}
