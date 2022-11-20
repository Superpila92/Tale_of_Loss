using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource audioSelection;
    [SerializeField] AudioSource audioClick;

    /*
    [SerializeField] AudioSource audioSourceClick;

    private void Awake()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }
    */
    void Update()
    {

    }


    public void OnPlay()
    {
        //audioSourceClick.Play();
        Debug.Log("Cargamos la siguiente escena");
        audioClick.Play();
        SceneManager.LoadScene("SampleScene");

    }

    public void OnOptions()
    {
        audioClick.Play();
        
    }


    public void OnExit()
    {
        audioClick.Play();
        Debug.Log("Salimos");
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

}
