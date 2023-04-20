using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpujeAnim : MonoBehaviour
{
    public PlayerMovement ply;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Empujable"))
        {
            ply.anim.SetTrigger("isDragging");
            ply.anim.SetBool("isDragging_bool", true);
        }
    }

}
