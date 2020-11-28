using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int lives;

    public int score;

    public Text livesText;

    public Text scoreText;

    public GameObject gameOverPanel;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        DisplayLives();
        DisplayScore();
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

    public void UpdateScore(int points)
    {
        score += points;

        DisplayScore();
    }

    private void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }
}
