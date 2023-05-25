using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuEscenaFinal : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausedMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    }

    public void Resume()
    {
        pausedMenuUI.SetActive(false);
        //Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pausedMenuUI.SetActive(true);
        //Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Menu()
    {
        GameIsPaused = false;
        //audioSourceClick.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("MainMenu");
    }

}
