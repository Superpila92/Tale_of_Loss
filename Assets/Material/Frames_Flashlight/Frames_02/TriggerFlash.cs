using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFlash : MonoBehaviour
{
    public bool megallamaCogida = false;
    public Flashlight fLight;
    public FlashStars fStars;

    public ParedesInvisHades walls;
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
            Invoke("ActivarAnim", 2f);
            Invoke("ActivarAnim2", 2f);
            Invoke("NosFuimo", 5f);

            walls.hadesWalls.gameObject.SetActive(true);
        }

    }
    public void ActivarAnim()
    {
        if (megallamaCogida == true)
        {
            fLight.gameObject.SetActive(true);
            fLight.flashlight.Play("flashlight");
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
    public void NosFuimo()
    {
        SceneManager.LoadScene("Final");
    }
}
