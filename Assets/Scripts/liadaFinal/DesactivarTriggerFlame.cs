using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarTriggerFlame : MonoBehaviour
{
    public GameObject triggerFlame;
    // Start is called before the first frame update
    void Start()
    {
        triggerFlame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
