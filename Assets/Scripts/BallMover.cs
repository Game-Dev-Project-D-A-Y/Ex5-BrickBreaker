using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool inPlay;

    public KeyCode keyToStart;

    public Transform ballStartPosition;

    public float startingForce;

    public Transform explosion;

    public GameManager gameManager;

    public Transform lifeAdderObject;

    // Start is called before the first frame update
    void Start()
    {
        inPlay = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        if (!inPlay)
        {
            transform.position = ballStartPosition.position;
        }

        if (Input.GetKeyDown(keyToStart) && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * startingForce);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BottomBorder")
        {
            rb.velocity = Vector2.zero;
            inPlay = false;
            gameManager.DecreaseLives();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Brick"))
        {
            int randomNumber = Random.Range(1, 1001);
            if (randomNumber <= 25)
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

            gameManager
                .UpdateScore(other
                    .gameObject
                    .GetComponent<BrickScript>()
                    .points);
            gameManager.BricksUpdate();
            Destroy(other.gameObject);
        }
        if (other.transform.CompareTag("HarderBrick"))
        {
            HarderBrickScript harderBrickScript =
                other.gameObject.GetComponent<HarderBrickScript>();
            if (harderBrickScript.brickLives > 1)
            {
                harderBrickScript.BreakBrick();
            }
            else
            {
                int randomNumber = Random.Range(1, 1001);
                if (randomNumber <= 10)
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
