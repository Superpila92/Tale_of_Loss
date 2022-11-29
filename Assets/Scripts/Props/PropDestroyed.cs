using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PropDestroyed : MonoBehaviour
{
    public int maxHealth = 1;
    int currentHealth;

    [SerializeField]
    UnityEngine.Object destructableRef;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            ExplodeThisGameObject();
        }
    }
    private void ExplodeThisGameObject()
    {
        
        GameObject destructable = (GameObject)Instantiate(destructableRef);

        destructable.transform.position = transform.position;

        Destroy(gameObject);
    }

}
