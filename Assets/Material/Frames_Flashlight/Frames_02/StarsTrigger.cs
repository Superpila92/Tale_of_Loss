using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsTrigger : MonoBehaviour
{
    public bool megallamaCogida = false;
    public FlashStars fStars;
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
        if (collision.gameObject.CompareTag("Player") && megallamaCogida == true)
        {
            Invoke("ActivarAnim2", 2f);
        }

    }
    public void ActivarAnim2()
    {
        if (megallamaCogida == true)
        {
            fStars.gameObject.SetActive(true);
            fStars.flashStars.Play("FlashStars");
        }

    }

}
