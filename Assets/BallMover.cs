using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{

    Rigidbody2D rb;

    private bool inPlay;

    [SerializeField] KeyCode keyToStart;
    [SerializeField] Transform ballPosition;
    [SerializeField] float startingForce;


    
    // Start is called before the first frame update
    void Start()
    {
        inPlay = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!inPlay)
        {
            transform.position = ballPosition.position;
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
        }
    }
}
