using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTrasCreditos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("GoToCreditosTras33Segundos", 31.5f);
    }
    public void GoToCreditosTras33Segundos()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
