using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBorderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LifeAdder")
        {
            Debug.Log("entered");
            Destroy(other.gameObject);
        }
    }
}
