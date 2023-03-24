using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pajaro : MonoBehaviour
{
    public float _speed = 6f;
    private float _endPosX;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime * _speed)); 

        //if(transform.position.x > _endPosX)
        //{
        //    Destroy(gameObject);
        //}
    }
    public void StartFloating(float speed, float endPosX)
    {
        _speed = speed;
        _endPosX = endPosX;
    }

}
