using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CutAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public LayerMask propsCut;

    public float attackRate = 2f;
    float nextAttackTime = 0f;


    public ParticleSystem aura;

    public AudioSource attackSound;

    private void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {

            if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.L))
            {

                StartCoroutine(Wait());
                Attack();
                aura.Play();
                nextAttackTime = Time.time + 1f / attackRate;

                attackSound.pitch = Random.Range(0.75f, 1f);
                attackSound.Play();

            }
            
        }

    }

    void Attack()
    {
        Collider2D[] hitProps = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, propsCut);

        foreach(Collider2D prop in hitProps)
        {
            prop.GetComponent<PropDestroyed>().TakeDamage(attackDamage);
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    IEnumerator Wait()
    {

        yield return new WaitForSeconds(1);
        //GetComponent<EdgeCollider2D>().enabled = false;
    }
}
