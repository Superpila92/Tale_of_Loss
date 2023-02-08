using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDrag : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.Play("Drag");
            anim.SetTrigger("isDragging");
        }
        
    }
}
