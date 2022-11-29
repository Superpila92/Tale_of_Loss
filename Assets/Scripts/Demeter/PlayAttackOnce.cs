using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAttackOnce : MonoBehaviour
{
    public Animator animAttack;
    public GameObject anim;
    public AudioSource sickle;
    // Start is called before the first frame update
    void Start()
    {
        animAttack = GetComponent<Animator>();
        AudioSource audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            sickle.Play();
            //anim.SetActive(true);
            animAttack.Play("animattack");
        }

    }


        
}
