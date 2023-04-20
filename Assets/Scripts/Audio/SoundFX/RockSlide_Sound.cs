using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RockSlide_Sound : MonoBehaviour
{
    public AudioSource rock;

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
        if (collision.gameObject.CompareTag("Empujable"))
        {
            rock.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        rock.Stop();
    }
}
