using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendElevator : MonoBehaviour
{
    public Elevator ele;

    public Collider2D[] Paredes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
             

            ele.EstaBajando = false;
            ele.EstaSubiendo = true;

            for (int i = 0; i < Paredes.Length; i++)
            {
                Paredes[i].enabled = true;
            }

            //ele.transform.position = Vector2.MoveTowards(ele.transform.position, ele.points[2].position, ele.speed * Time.deltaTime);
        }
    }
}
