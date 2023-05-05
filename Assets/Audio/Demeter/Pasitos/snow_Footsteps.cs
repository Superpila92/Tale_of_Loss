using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snow_Footsteps : MonoBehaviour
{
    public GameObject snowFootstep;
    public PlayerMovement ply;

    //public AudioSource snow;

    // Start is called before the first frame update
    void Start()
    {
        snowFootstep.SetActive(false);
        //AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void SnowFootsteps()
    {
        //snow.pitch = Random.Range(0.4f, 1f);
        snowFootstep.SetActive(true);
    }
    public void StopSnowFootsteps()
    {
        snowFootstep.SetActive(false);
    }


}
