using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarderBrickScript : MonoBehaviour
{
    public int points;
    public int brickLives;
    private SpriteRenderer brickSprite;

    public void BreakBrick()
    {
        brickLives--;
        brickSprite.color = Color.blue;
    }
    // Start is called before the first frame update
    void Start()
    {
        brickSprite = GetComponent<SpriteRenderer>();
    }
}
