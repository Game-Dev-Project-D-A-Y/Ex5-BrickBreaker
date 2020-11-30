using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBorderScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy LifeAdders
        if (other.tag == GameManager.LIFE_ADDER)
        {
            Destroy(other.gameObject);
        }
    }
}
