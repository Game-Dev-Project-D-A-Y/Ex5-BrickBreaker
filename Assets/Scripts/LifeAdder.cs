using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAdder : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -1f) * speed * Time.deltaTime);
    }
}
