using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPitchMenuSounds : MonoBehaviour
{
    public AudioSource soundFX;
    // Start is called before the first frame update
    void Start()
    {
        soundFX.pitch = Random.Range(0.75f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
