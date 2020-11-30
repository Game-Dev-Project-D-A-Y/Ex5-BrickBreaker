using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    public int duration;
 
    // Update is called once per frame
    void Update()
    {  
        Destroy(gameObject,duration);
    }
}
