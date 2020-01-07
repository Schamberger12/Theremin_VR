using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual_Pitch_Control : MonoBehaviour
{
    [SerializeField]
    AudioSource sine; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.U))
        {
            sine.pitch -= 0.1f; 
        }
        if (Input.GetKey(KeyCode.I))
        {
            sine.pitch += 0.1f; 
        }
    }
}
