using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float followSpeed;

    public Transform followTarget;

    public PressurePlate PP;

    public float speed;
    public int startingPoint;
    public Transform[] points;
    //private int i;

    public bool EstaBajando = true;
    public bool EstaSubiendo = false;

    public Collider2D[] Paredes;

    void Start()
    {
        transform.position = points[startingPoint].position;
    }


    void Update()
    {
        if (PP.transform.position.y <= -890f && EstaBajando)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[1].position, speed * Time.deltaTime);
        }

        if (EstaSubiendo)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[2].position, speed * Time.deltaTime); 
        }

        if (transform.position == points[2].position && Paredes[0].enabled == true)
        {
            for (int i = 0; i < Paredes.Length; i++)
            {
                Paredes[i].enabled = false;
            }
        }


    }

    
    //IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(20);
    //}


}
