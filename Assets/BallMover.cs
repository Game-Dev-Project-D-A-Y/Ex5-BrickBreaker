using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{

    Rigidbody2D rb;

    private bool inPlay;

    [SerializeField] KeyCode keyToStart;
    [SerializeField] Transform ballStartPosition;
    [SerializeField] float startingForce;
    public Transform explosion;
    public GameManager gameManager;


    
    // Start is called before the first frame update
    void Start()
    {
        inPlay = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameOver)
        {
            return;
        }

        if(!inPlay)
        {
            transform.position = ballStartPosition.position;
        }

        if(Input.GetKeyDown(keyToStart) && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * startingForce);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "BottomBorder"){
            Debug.Log("Hit Bottom border");
            rb.velocity = Vector2.zero;
            inPlay = false;
            gameManager.DecreaseLives();
        }
     
    }
    void OnCollisionEnter2D(Collision2D other)
    {
           if(other.transform.CompareTag("Brick"))
        {
           Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject,2.5f);

            gameManager.UpdateScore(other.gameObject.GetComponent<BrickScript>().points);

            Destroy(other.gameObject);
        }
    }

}
