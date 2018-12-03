using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// decides when the game is won or lost
/// pauses the game when asked
/// starts the game when ready
/// and
/// locks the cursor
/// </summary>
public class GameManager : MonoBehaviour
{
    //public//
    public bool isGamePaused = false;
    public bool hasGameStarted = false;

    //private//
    //Player r_player;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform player_Spawnpoint;

    [SerializeField] Camera sceneCamera;

    Scene currentScene;

    bool hasWon = false;

    //lockstate of the cursor
    bool lockstate = false;

    private void Awake()
    {
        ///if the current scene is the game scene
        ///"start" the game
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 1)
        {
            hasGameStarted = true;
        }
    }

    void Start()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            ToggleCursorLock();
        }

        playerPrefab = Instantiate(playerPrefab, player_Spawnpoint);
    }

    void Update()
    {
        ///if game not started, skip rest below
        if (!hasGameStarted)
        {
            return;
        }

        ///get player stuff
        //if (r_player == null)
        //{
        //    r_player = FindObjectOfType<Player>();
        //}

        ///if ESC pressed, toggle the cursor lock
        ///which triggers the pause menu when the player is alive
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if (r_player.gameObject.activeInHierarchy)
            {
                ShowMenu();
            }
        }
    }

    /// <summary>
    /// Lock the cursor and hide it
    /// </summary>
    public void ToggleCursorLock()
    {
        lockstate = !lockstate;

        if (lockstate)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
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

    /// <summary>
    /// resumes the game
    /// </summary>
    void ResumeGame()
    {
        isGamePaused = false;

        Time.timeScale = 1;
    }

    /// <summary>
    /// pauses the game
    /// </summary>
    void PauseGame()
    {
        isGamePaused = true;

        Time.timeScale = 0;
    }
}
