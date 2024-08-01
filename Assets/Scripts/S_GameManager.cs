using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject tutorPanel;
    public bool gamePaused = false;

    public AudioSource bgm;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
        }
        pauseMenu.SetActive(gamePaused);
        bgm.mute = gamePaused;

        if (gamePaused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void LoadMainMenu()
    {
        gamePaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenTutor()
    {
        tutorPanel.SetActive(true);
    }

    public void CloseTutor()
    {
        tutorPanel.SetActive(false);
    }

    public void CloseMenu()
    {
        gamePaused = false;
    }
}
