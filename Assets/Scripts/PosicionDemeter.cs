using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionDemeter : MonoBehaviour
{
    private Vector3 ChangePosition;

    // Start is called before the first frame update
    void Start()
    {
        ChangePosition = transform.position;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PositionX")
        {
            ChangePosition.z = -2f;
        }
    }
 }
