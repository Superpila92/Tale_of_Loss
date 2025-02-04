using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ZoomOut_Musical : MonoBehaviour
{
    public CameraLimits cam;
    public float camSize;
    public float camSizeLimit;
    public float increment;

    public float timeLerp;
    public float timelerpValue;
    public bool zoomOut = false;

    //public float offsetY;
    //public float offsetX;
    //public float leftLimit;
    //public float bottomLimit;

    //public AudioSource gameMusic1;
    //public AudioSource gameMusic2;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomOut)
        {
            ZoomOut();
            //CenterCam();
        }

        camSize = Camera.main.fieldOfView;
        timelerpValue = timeLerp * Time.deltaTime;
    }
    private void ZoomOut()
    {
        if (Camera.main.fieldOfView < camSizeLimit)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, Camera.main.fieldOfView + increment, timeLerp * Time.deltaTime);
        }
        else if (Camera.main.fieldOfView > camSizeLimit)
        {
            zoomOut = false;
        }
    }
    //private void CenterCam()
    //{
    //    cam.offset.y = Mathf.Lerp(offsetY, Camera.main.orthographicSize + increment, timeLerp * Time.deltaTime);
    //    cam.offset.x = Mathf.Lerp(offsetX, Camera.main.orthographicSize + increment, timeLerp * Time.deltaTime);
    //    //cam.leftLimit = Mathf.Lerp(leftLimit, Camera.main.orthographicSize + increment, timeLerp * Time.deltaTime);
    //    cam.bottomLimit = Mathf.Lerp(bottomLimit, Camera.main.orthographicSize + increment, timeLerp * Time.deltaTime);
    //}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //gameMusic1.Stop();
            //gameMusic2.Play();
            zoomOut = true;
            ZoomOut();
        }
    }
}
