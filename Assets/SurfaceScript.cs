﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class SurfaceScript : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField]
    float speed = 1f;

    public GameManager gameManager;

    private Camera camera;

    private float cameraLeftBorder;

    private float cameraRightBorder;

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
        float horizontal = Input.GetAxis("Horizontal"); // +1 if right arrow is pushed, -1 if left arrow is pushed, 0 otherwise
        transform
            .Translate(Vector2.right * horizontal * Time.deltaTime * speed);

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
        if(other.tag == "LifeAdder")
        {
            gameManager.IncreaseLives();
            Debug.Log("touched object");
            Destroy(other.gameObject);
        }


    }
}
