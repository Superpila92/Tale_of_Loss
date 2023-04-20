using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadesArm_Sound : MonoBehaviour
{
    public AudioSource arm;

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
        if (collision.gameObject.CompareTag("Weapon"))
        {
            arm.Play();
        }
    }
}