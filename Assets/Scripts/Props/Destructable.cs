using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    Vector2 forceDirection;

    [SerializeField]
    int torque;

    Rigidbody2D rb2d;
    //public AudioSource propDestroyedAudio;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        //propDestroyedAudio.Play();

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(forceDirection);
        rb2d.AddTorque(torque);

        float randTorque = UnityEngine.Random.Range(-500, 500);
        float randForceX = UnityEngine.Random.Range(forceDirection.x - 350, forceDirection.x + 350);
        float randForceY = UnityEngine.Random.Range(forceDirection.y, forceDirection.x + 350);

        forceDirection.x = randForceX;
        forceDirection.y = randForceY;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
