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
        camera = Camera.main;

        cameraRightBorder = camera.aspect * camera.orthographicSize;
        cameraLeftBorder = -cameraRightBorder;

        Debug.Log("Left border: " + cameraLeftBorder);
    }

    void Update()
    {
        if (gameManager.gameOver)
        {
            return;
        }

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

        if (
            transform.position.x - (transform.localScale.x / 2) <
            cameraLeftBorder
        )
        {
            transform.position =
                new Vector2(cameraLeftBorder + (transform.localScale.x / 2),
                    transform.position.y);
        }
        if (
            transform.position.x + (transform.localScale.x / 2) >
            cameraRightBorder
        )
        {
            transform.position =
                new Vector2(cameraRightBorder - (transform.localScale.x / 2),
                    transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LifeAdder")
        {
            gameManager.IncreaseLives();
            Destroy(other.gameObject);
        }
    }
}
