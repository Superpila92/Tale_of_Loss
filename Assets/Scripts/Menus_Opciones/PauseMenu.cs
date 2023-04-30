using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    //public BikeController BikeController;

    public static bool GameIsPaused = false;
    public GameObject pausedMenuUI;

    //[SerializeField] AudioSource audioSourcePause;
    //[SerializeField] AudioSource audioSourceClick;

    public PlayerMovement plyM;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.P)) || (Input.GetKeyDown(KeyCode.Escape)))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
                
            }

        }

        if (GameIsPaused == true)
        {
            plyM.canFlip = false;
        }


    }

    public void Resume()
    {
        pausedMenuUI.SetActive(false);
        //audioSourceClick.Play();
        Time.timeScale = 1f;
        GameIsPaused = false;
        plyM.canFlip = true;
    }

    void Pause()
    {
        pausedMenuUI.SetActive(true);
        //audioSourcePause.Play();
        Time.timeScale = 0f;
        GameIsPaused = true;
        plyM.canFlip = false;
    }

    public void Menu()
    {
        Debug.Log("Loading settings...");
        //audioSourceClick.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainMenu");
    }



}
