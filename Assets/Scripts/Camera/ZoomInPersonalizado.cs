using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInPersonalizado : MonoBehaviour
{
    public CameraLimits cam;
    public float camSize;
    public float camSizeLimit;
    public float increment;

    public float timeLerp;
    public float timelerpValue;
    public bool zoomIn = false;

    public float cameraLimitBottom;
    public float offsetY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (zoomIn)
        {
            ZoomOut();
            CenterCam();
        }

        camSize = Camera.main.orthographicSize;
        timelerpValue = timeLerp * Time.deltaTime;
    }
    private void ZoomOut()
    {
        if (Camera.main.orthographicSize > camSizeLimit)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + -increment, timeLerp * Time.deltaTime);
        }
        else if (Camera.main.orthographicSize < camSizeLimit)
        {
            zoomIn = false;
        }
    }
    private void CenterCam()
    {
        cam.bottomLimit = Mathf.Lerp(cameraLimitBottom, Camera.main.orthographicSize + increment, timeLerp * Time.deltaTime);
        cam.offset.y = Mathf.Lerp(offsetY, Camera.main.orthographicSize + increment, timeLerp * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            zoomIn = true;
            ZoomOut();
        }
    }
}
