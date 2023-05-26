using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPass : MonoBehaviour
{
    public GameObject Filter;
    // Start is called before the first frame update
    void Start()
    {
        Filter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
