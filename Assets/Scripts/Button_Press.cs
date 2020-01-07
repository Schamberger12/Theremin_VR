using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Press : MonoBehaviour
{
    [SerializeField]
    GameObject button;

    [SerializeField]
    int bpm_change;

    [SerializeField]
    Material button_color;

    [SerializeField]
    Material pressed_color; 

    [SerializeField]
    Metronome metronome_script; 

    [SerializeField]
    private bool pressed = false; 


    private void OnTriggerEnter(Collider other)
    {
        if (pressed == false)
        {
            metronome_script.Change_BPM(bpm_change);

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

}
