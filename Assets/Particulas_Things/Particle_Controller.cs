using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Controller : MonoBehaviour
{
    public PlayerMovement PL;

    [SerializeField] ParticleSystem movementParticle;
    [SerializeField] ParticleSystem jumpParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0,2f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D playerRB;

    float counter;


    private void Update()
    {
        counter += Time.deltaTime;

        if(Mathf.Abs(playerRB.velocity.x) > occurAfterVelocity)
        {
            movementParticle.Play();
            counter = 0;
        }
        if (Mathf.Abs(playerRB.velocity.y) > 0)
        {
            movementParticle.Stop();
            
        }
        if(PL.IsGrounded())
        {
            if (Input.GetButtonDown("Jump"))
            {
                jumpParticle.Play();
            }

        }
    }
}
