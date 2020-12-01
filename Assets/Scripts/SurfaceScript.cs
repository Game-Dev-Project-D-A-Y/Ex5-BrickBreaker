using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class SurfaceScript : MonoBehaviour
{
    public GameManager gameManager;

    private Camera camera;

    private float cameraLeftBorder;

    private float cameraRightBorder;

    private bool isDragging;

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    void Start()
    {
        // Get camera borders
        camera = Camera.main;

        cameraRightBorder = camera.aspect * camera.orthographicSize;
        cameraLeftBorder = -cameraRightBorder;
    }

    void Update()
    {
        // Do nothing when game is over
        if (gameManager.gameOver)
        {
            return;
        }

        // Drag the surface horizontally with mouse
        if (isDragging)
        {
            Vector3 point =
                Camera
                    .main
                    .ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                        (
                        transform.position.y - Camera.main.transform.position.y
                        ),
                        (
                        transform.position.z - Camera.main.transform.position.z
                        )));

    

            point.y = transform.position.y;
            point.z = transform.position.z;
            transform.position = point;

        }

        GameObject leftBorder = GameObject.Find("LeftBorder");
        // Check Limits
        if (
            transform.position.x - (transform.localScale.x / 2) <
            //cameraLeftBorder
            leftBorder.gameObject.transform.position.x
        )

        
        {
            transform.position =
                new Vector2(cameraLeftBorder + (transform.localScale.x / 2),
                    transform.position.y);
        }

        GameObject rightBorder = GameObject.Find("RightBorder");
        if (
            transform.position.x + (transform.localScale.x / 2) >
            //cameraRightBorder
            rightBorder.gameObject.transform.position.x
        )
        {
            transform.position =
                new Vector2(cameraRightBorder - (transform.localScale.x / 2),
                    transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == GameManager.LIFE_ADDER)
        {
            gameManager.IncreaseLives();
            Destroy(other.gameObject);
        }
    }
}
