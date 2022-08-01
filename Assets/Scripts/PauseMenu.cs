using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject resumeButton, quitButton;

    public static bool isPause;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Enable Debug Button 1") || Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnPause();
        }
    }

    void PauseUnPause()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            isPause = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            //Clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected object
            EventSystem.current.SetSelectedGameObject(resumeButton);
        }
        else
        {
            isPause = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        isPause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadMainMenu(int index)
    {
        isPause = false;
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
        EnemySpawner.enemiesDefeated = 0;
        TimeCounter.bossAppeared = false;
    }
}