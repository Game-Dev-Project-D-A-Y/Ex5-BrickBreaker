using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This script represents the ball moves and collides.
*/
public class BallMover : MonoBehaviour
{
    public KeyCode keyToStart;

    public Transform ballStartPosition;

    public float startingForce;

    public Transform explosion;

    public GameManager gameManager;

    public Transform lifeAdderObject;

    public float chanceToLifeAdder;

    private Rigidbody2D rb;

    private bool inPlay;

    // Start is called before the first frame update
    void Start()
    {
        inPlay = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Do nothing when game is over
        if (gameManager.gameOver)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        // Attach the ball to surface before starting
        if (!inPlay)
        {
            transform.position = ballStartPosition.position;
        }

        // Start playing when pushing keyToStart
        if (Input.GetKeyDown(keyToStart) && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * startingForce);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GameManager.LIFE_ADDER)
        {
            return;
        }

        // Handle collision with bottom border
        if (other.tag == GameManager.BOTTOM_BORDER)
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
            gameManager.DecreaseLives();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        int randomNumber = Random.Range(1, 101);

        // Handle collisions with bricks
        if (other.transform.CompareTag(GameManager.BRICK))
        {
            BrickScript brickScript =
                other.gameObject.GetComponent<BrickScript>();

            // Instantiate LifeAdder randomally - chanceToLifeAdder chance to get a LifeAdder.
            if (randomNumber <= chanceToLifeAdder)
            {
                Instantiate(lifeAdderObject,
                other.transform.position,
                other.transform.rotation);
            }

            // Explosion effect when breaking a brick
            Transform newExplosion =
                Instantiate(explosion,
                other.transform.position,
                other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);

            gameManager.UpdateScore(brickScript.points);
            gameManager.BricksUpdate();
            Destroy(other.gameObject);
        }

        // Handle collisions with harder bricks
        if (other.transform.CompareTag(GameManager.HARDER_BRICK))
        {
            HarderBrickScript harderBrickScript =
                other.gameObject.GetComponent<HarderBrickScript>();

            if (harderBrickScript.brickLives > 1)
            {
                harderBrickScript.BreakBrick();
            }
            else
            {
                if (randomNumber <= chanceToLifeAdder)
                {
                    Instantiate(lifeAdderObject,
                    other.transform.position,
                    other.transform.rotation);
                }

                Transform newExplosion =
                    Instantiate(explosion,
                    other.transform.position,
                    other.transform.rotation);
                Destroy(newExplosion.gameObject, 2.5f);

                gameManager.UpdateScore(harderBrickScript.points);
                gameManager.BricksUpdate();
                Destroy(other.gameObject);
            }
        }
    }
}
