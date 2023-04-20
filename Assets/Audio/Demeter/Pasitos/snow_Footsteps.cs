using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snow_Footsteps : MonoBehaviour
{
    public GameObject snowFootstep;
    public PlayerMovement ply;


    // Start is called before the first frame update
    void Start()
    {
        snowFootstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void SnowFootsteps()
    {
        snowFootstep.SetActive(true);
    }
    public void StopSnowFootsteps()
    {
        snowFootstep.SetActive(false);
    }


}
