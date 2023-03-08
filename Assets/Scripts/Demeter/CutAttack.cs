using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public LayerMask propsCut;

    public float attackRate = 2f;
    float nextAttackTime = 0f;


    public ParticleSystem aura;


    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {

            if (Input.GetKeyDown(KeyCode.L))
            {
                Attack();
                aura.Play();
                nextAttackTime = Time.time + 1f / attackRate;

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
}
