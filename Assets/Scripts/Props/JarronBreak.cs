using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarronBreak : MonoBehaviour
{
    [SerializeField]
    public int health = 1;

    [SerializeField]
    UnityEngine.Object destructableRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            health--;

            if (health <= 0)
            {
                ExplodeThisGameObject();
            }
        }
    }

    private void ExplodeThisGameObject()
    {
        GameObject destructable = (GameObject)Instantiate(destructableRef);

        destructable.transform.position = transform.position;

        Destroy(gameObject);
    }
}
