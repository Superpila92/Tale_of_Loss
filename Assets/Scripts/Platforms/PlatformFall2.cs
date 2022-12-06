using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall2 : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            PlatformManager2.Instance.StartCoroutine("SpawnPlatform", new Vector2(transform.position.x, transform.position.y));

            Invoke("DropPlatform", 0.5f);
            Destroy(gameObject, 4f);
        }

    }
    
    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
