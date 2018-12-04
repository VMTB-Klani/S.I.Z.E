using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{

    bool isGamePaused = false;

    public GameObject m_UIPauseMenu;


    void Update()
    {
        ///if ESC pressed, open PauseMenu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMenu();
        }
    }

    /// <summary>
    /// resumes the game
    /// </summary>
    public void ResumeGame()
    {
        isGamePaused = false;

        m_UIPauseMenu.SetActive(false);

        Time.timeScale = 1;
    }

    /// <summary>
    /// pauses the game
    /// </summary>
    void PauseGame()
    {
        isGamePaused = true;

        m_UIPauseMenu.SetActive(true);

        Time.timeScale = 0;
    }

    /// <summary>
    /// shows and hides the pause menu
    /// </summary>
    public void ShowMenu()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

}
