using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    int duration = 5;
   
    void start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
           Destroy(gameObject,duration);
        
        
    }
}
