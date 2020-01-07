using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK; 

public class Theremin : MonoBehaviour
{
    [SerializeField]
    GameObject right_hand_sim;

    [SerializeField]
    GameObject left_hand_sim;

    [SerializeField]
    GameObject left_hand_VR;

    [SerializeField]
    GameObject right_hand_VR;

    List<Transform> hands;

    [SerializeField]
    private AudioSource sound;
    [SerializeField]
    private Transform pitch_antenna;
    [SerializeField]
    private float pitch_dist;
    [SerializeField]
    private Transform volume_antenna;
    [SerializeField]
    private float volume_dist;

    // set pitch_min to 0 and pitch_max to how high the unity audioSource attribute 'pitch'
    // can go
    // In this instance, its a range of 0-22.
    
    [SerializeField]
    float pitch_max;

    [SerializeField]
    float pitch_min; 


    private void Awake()
    {
        hands = new List<Transform>();
        hands.Add(left_hand_sim.transform);
        hands.Add(right_hand_sim.transform);
        hands.Add(left_hand_VR.transform);
        hands.Add(right_hand_VR.transform);
    }

    void Update()
    {
        float nearestPitchProximity = Mathf.Infinity;
        float nearestVolProximity = Mathf.Infinity;

        foreach (Transform hand in hands)
        {
            float thisDistance = Vector2.Distance(new Vector2(pitch_antenna.position.x, pitch_antenna.position.z), new Vector2(hand.position.x, hand.position.z));
            nearestPitchProximity = Mathf.Min(nearestPitchProximity, thisDistance);
            nearestVolProximity = Mathf.Min(nearestVolProximity, Vector3.Distance(volume_antenna.transform.position, hand.transform.position));
        }
        // Maps distance of the closest hand to the range of the pitch and volume. 
        sound.pitch = Mathf.Lerp(pitch_max, pitch_min, Mathf.InverseLerp(0, pitch_dist, nearestPitchProximity));
        sound.volume = Mathf.Lerp(0f, 3f, Mathf.InverseLerp(0, volume_dist, nearestVolProximity)); 

    }

}

