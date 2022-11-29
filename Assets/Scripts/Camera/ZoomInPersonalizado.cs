using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInPersonalizado : MonoBehaviour
{
    public SmoothCamera cam;
    public float camSize;
    public float camSizeLimit;
    public float increment;

    public float timeLerp;
    public float timelerpValue;
    public bool zoomIn = false;

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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            zoomIn = true;
            ZoomOut();
        }
    }
}
