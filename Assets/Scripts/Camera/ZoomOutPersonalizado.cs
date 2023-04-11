using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOutPersonalizado : MonoBehaviour
{
    public CameraLimits cam;
    public float camSize;
    public float camSizeLimit;
    public float increment;

    public float timeLerp;
    public float timelerpValue;
    public bool zoomOut = false;

    //public float cameraLimitBottom;
    //public float cameraLimitLeft;
    public float offsetY;

    // Start is called before the first frame update
    void Start()
    {
        
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
    //    cam.bottomLimit = Mathf.Lerp(cameraLimitBottom, Camera.main.fieldOfView + increment, timeLerp * Time.deltaTime);
    //    //cam.leftLimit = Mathf.Lerp(cameraLimitLeft, Camera.main.orthographicSize + increment, timeLerp * Time.deltaTime);
    //    cam.offset.y = Mathf.Lerp(offsetY, Camera.main.fieldOfView + increment, timeLerp * Time.deltaTime);
    //}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            zoomOut = true;
            ZoomOut();
        }
    }
}
