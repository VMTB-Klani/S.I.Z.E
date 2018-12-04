using System;
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
    public bool setNewText = false;
    public float starttime;

    //private//
    private UIHandler r_uiHandler;

    //variables for timer
    float timeleft = 5;

    //Player r_player;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform player_Spawnpoint;

    [SerializeField] Camera sceneCamera;

    Scene currentScene;

    bool hasWon = false;

    //lockstate of the cursor
    bool lockstate = false;

    public int m_CountKey = 0;

    private void Awake()
    {
        r_uiHandler = FindObjectOfType<UIHandler>();

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
        if ((starttime + timeleft < Time.time))
        {
            r_uiHandler.StoryText.text = "";
        }

        SwitchInfoText();
    }

    private void SwitchInfoText()
    {
        switch (m_CountKey)
        {
            case 0:
                break;
            case 1:
                if (setNewText)
                {
                    r_uiHandler.StoryText.text = "This is not the right key";
                    setNewText = false;
                }
                break;
            case 2:
                if (setNewText)
                {
                    r_uiHandler.StoryText.text = "This key doesn't fit too";
                    setNewText = false;
                }
                break;
            case 3:
                if (setNewText)
                {
                    r_uiHandler.StoryText.text = "The keys look all the same";
                    setNewText = false;
                }
                break;
            case 4:
                if (setNewText)
                {
                    r_uiHandler.StoryText.text = "I don't think any key will fit";
                    setNewText = false;
                }
                break;
            default:
                if (setNewText)
                {
                    r_uiHandler.StoryText.text = "I don't think any key will fit";
                    setNewText = false;
                }
                break;
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
}

