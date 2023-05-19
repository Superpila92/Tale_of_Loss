using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame2GoHere : MonoBehaviour
{
    private PlayerMovement thePlayer;
    public Transform flameHere;

    public bool llamaColocada = false;
    public ChangeCamera2 cc;
    public CabesaDesactivada cabesa;
    public float num = 5f;

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

        if (llamaColocada == true && num == 5f)
        {
            Invoke("UnlockCabesa", 3f);
            Invoke("DelayCabesa", 4f);
            num++;
        }


    }
    private void UnlockCabesa()
    {
        cc.mainCam.depth = 0;
        cc.cabesaCam.depth = 1;
        cc.nowMainCam = false;
        Invoke("VolverCamNormal", 6f);

    }
    private void DelayCabesa()
    {
        cabesa.gameObject.SetActive(false);
    }
    private void VolverCamNormal()
    {
        cc.mainCam.depth = 2;
        cc.cabesaCam.depth = 0;
        cc.nowMainCam = true;
    }
}
