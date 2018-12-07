using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    //private//
    GameManager r_gameManager;

    bool isGamePaused = false;

    public GameObject m_UIPauseMenu;
    public GameObject crosshair;

    private void Awake()
    {
        r_gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        m_UIPauseMenu.SetActive(false);
    }

    void Update()
    {
        ///if ESC pressed, open PauseMenu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowMenu();
            r_gameManager.ToggleCursorLock();
        }
    }

    /// <summary>
    /// resumes the game
    /// </summary>
    public void ResumeGame()
    {
        isGamePaused = false;

        m_UIPauseMenu.SetActive(false);
        crosshair.SetActive(true);

        Time.timeScale = 1;
    }

    /// <summary>
    /// pauses the game
    /// </summary>
    void PauseGame()
    {
        isGamePaused = true;

        m_UIPauseMenu.SetActive(true);
        crosshair.SetActive(false);

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