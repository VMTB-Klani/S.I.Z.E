using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    //private//
    PauseManager r_pauseManager;
    GameManager r_gameManager;

    private void Awake()
    {
        r_pauseManager = FindObjectOfType<PauseManager>();
        r_gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    #region MenuStuff
    /// <summary>
    /// load a specific scene
    /// set timescale to 1 everything runs
    /// </summary>
    /// <param name="_sceneIndex"></param>
    public void LoadScene(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
        Time.timeScale = 1;
    }

    /// <summary>
    /// quit app
    /// </summary>
    public void QuitApplication()
    {
        Debug.LogWarning("Quit application");
        Application.Quit();
    }

    /// <summary>
    /// resume game, disable menu/s
    /// </summary>
    public void ResumeGame()
    {
        r_gameManager.ToggleCursorLock();
        r_pauseManager.ShowMenu();
    }
    #endregion
}
