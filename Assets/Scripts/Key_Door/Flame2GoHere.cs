using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame2GoHere : MonoBehaviour
{
    private PlayerMovement thePlayer;
    public Transform flameHere;

    public ChangeCamera2 cam;
    public CabesaDesactivada cabesa;

    public FlameHades flame;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (thePlayer.followingKey != null)
            {
                thePlayer.followingFlame.Target = flameHere.transform;
            }
        }
        if(collision.tag == "Player" && flame.numMagico >= 2)
        {
            Invoke("CameraChange", 3f);
            Invoke("GetBackCam", 8f);
            flame.numMagico = flame.numMagico - 9999f;
        }
    }
    public void CameraChange()
    {
        cam.mainCam.depth = 0;
        cam.cabesaCam.depth = 1;
        cam.nowMainCam = false;

        cabesa.gameObject.SetActive(false);
    }
    public void GetBackCam()
    {
        cam.mainCam.depth = 1;
        cam.cabesaCam.depth = 0;
        cam.nowMainCam = true;
    }

}
