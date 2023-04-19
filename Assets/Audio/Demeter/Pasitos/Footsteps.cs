using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject footstep;
    public PlayerMovement ply;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void footsteps()
    {
        footstep.SetActive(true);
    }
    public void Stopfootsteps()
    {
        footstep.SetActive(false);
    }



}
