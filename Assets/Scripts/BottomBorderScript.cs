using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBorderScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LifeAdder")
        {
            Debug.Log("entered");
            Destroy(other.gameObject);
        }
    }
}
