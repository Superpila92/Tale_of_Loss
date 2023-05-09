using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves_Pitch : MonoBehaviour
{
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sound.pitch = Random.Range(0.75f, 1f);
    }
}
