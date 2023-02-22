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
    private int i;

    void Start()
    {
        transform.position = points[startingPoint].position;
    }


    void Update()
    {
        if(PP.transform.position.y < -890f)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[1].position, speed * Time.deltaTime);
        }


    }

}
