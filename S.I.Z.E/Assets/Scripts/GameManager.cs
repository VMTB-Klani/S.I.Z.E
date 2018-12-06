using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public//
    public bool setNewText = false;
    public float startTime;

    //private//
    UIHandler r_uiHandler;

    ///variables for timer
    float timeLeft = 5;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawnpoint;
    [SerializeField] Camera sceneCamera;

    ///lockstate of the cursor
    bool lockstate;

    public int m_CountKey = 0;

    private void Awake()
    {
        r_uiHandler = FindObjectOfType<UIHandler>();
    }

    void Start()
    {
        lockstate = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerPrefab = Instantiate(playerPrefab, playerSpawnpoint);
    }

    void Update()
    {
        if ((startTime + timeLeft < Time.time))
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

