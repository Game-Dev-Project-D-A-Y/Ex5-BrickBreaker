using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    [SerializeField]int duration;
   
    void start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
           Destroy(gameObject,duration);
        
        
    }
}
