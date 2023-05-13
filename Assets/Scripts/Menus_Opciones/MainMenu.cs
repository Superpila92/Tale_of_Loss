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
    
    [SerializeField] Animator anim;

    private void Awake()
    {
        //audioSource = GetComponentInChildren<AudioSource>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("IsLoadingPlay", false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        { 
            audioSelection.Play();
        }

    }


    public void OnPlay()
    {
        audioClick.Play();
        Invoke("GameScene", 3f);
        anim.SetBool("IsLoadingPlay", true);
        Debug.Log("escenaplay1");

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

    public void GameScene()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("escenaplay2");
    }
}
