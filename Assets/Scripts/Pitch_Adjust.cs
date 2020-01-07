using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class Pitch_Adjust : MonoBehaviour
{


    [SerializeField]
    AudioMixer theremin_mixer; 

    [SerializeField]
    Material button_color;

    [SerializeField]
    Material pressed_color;

    [SerializeField]
    GameObject button;

    [SerializeField]
    float pitch;

    [SerializeField]
    float current_pitch; 


    bool pressed = false;

    private void Start()
    {
        if (theremin_mixer.GetFloat("Theremin_Pitch", out current_pitch))
        {
            Debug.Log("Exists!"); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (pressed == false)
        {

            Change_Pitch(); 
            StartCoroutine(Button_Pressed(0.5f));
        }
    }

    private IEnumerator Button_Pressed(float timer)
    {
        pressed = true;
        button.GetComponent<Renderer>().material = pressed_color;
        yield return new WaitForSeconds(timer);
        pressed = false;
        button.GetComponent<Renderer>().material = button_color;
    }

    private void Change_Pitch()
    {
        current_pitch += pitch;
        theremin_mixer.SetFloat("Theremin_Pitch", current_pitch);
    }
}
