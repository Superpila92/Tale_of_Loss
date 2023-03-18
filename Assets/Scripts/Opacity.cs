using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opacity : MonoBehaviour
{
    public Image panel;
    public float OpacityPanel = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OpacityPanel = 0f;
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, OpacityPanel );
        }
    }
}
