using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    float duration = 5f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > duration)
        {
            Destroy(gameObject);
        }
        
    }
}
