using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Pilar_Llama : MonoBehaviour
{
    public Animator anim;
    public PilarInSite pilarSite;
    public int counterFlames = 2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("areFlamesIn", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(counterFlames == 0)
        {
            anim.SetBool("areFlamesIn", true);
        }
    }
}

