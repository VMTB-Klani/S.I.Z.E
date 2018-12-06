using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    //public//
    [Header("Stuff for settings")]
    public AudioMixer audioMixer;

    [Header("Buttons for SFX")]
    public Button[] normalButtons;
    public Button[] positiveButtons;

    //private//
    PauseManager r_pauseManager;
    GameManager r_gameManager;
    FP_Camera r_fpCamera;

    [SerializeField] AudioSource normalButtonSource;
    [SerializeField] AudioSource positiveButtonSource;

    float soundValueMaster;//for muting the sound completely

    private void Awake()
    {
        r_pauseManager = FindObjectOfType<PauseManager>();
        r_gameManager = FindObjectOfType<GameManager>();
        r_fpCamera = FindObjectOfType<FP_Camera>();
    }

    void Start()
    {
        SetAudioStartValues();
    }

    void Update()
    {
        ///play a sound(clip) on button press
        ///add infinite buttons!!^^
        for (int i = 0; i < normalButtons.Length; i++)
        {
            normalButtons[i].onClick.AddListener(() => PlaySound("normal"));
        }

        for (int i = 0; i < positiveButtons.Length; i++)
        {
            positiveButtons[i].onClick.AddListener(() => PlaySound("positive"));
        }

        if (r_fpCamera == null)
        {
            r_fpCamera = FindObjectOfType<FP_Camera>();
        }

        if (audioMixer != null)
        {
            MuteSound();
        }
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

    #region AUDIO
    void SetAudioStartValues()
    {
        if (audioMixer != null)
        {
            audioMixer.SetFloat("master_Volume", -5);
            audioMixer.SetFloat("music_Volume", -10f);
            audioMixer.SetFloat("sound_Volume", 0);
        }
    }

    /// <summary>
    /// set masterVol to slider val
    /// </summary>
    /// <param name="_volume"></param>
    public void SetMasterVolume(float _volume)
    {
        audioMixer.SetFloat("master_Volume", _volume);
    }

    /// <summary>
    /// set musicVol to slider val
    /// </summary>
    /// <param name="_volume"></param>
    public void SetMusicVolume(float _volume)
    {
        audioMixer.SetFloat("music_Volume", _volume);
    }

    /// <summary>
    /// set soundVol to slider val
    /// </summary>
    /// <param name="_volume"></param>
    public void SetSoundVolume(float _volume)
    {
        audioMixer.SetFloat("sound_Volume", _volume);
    }

    /// <summary>
    /// plays the sound clip of the audio source
    /// </summary>
    void PlaySound(string _sourceType)
    {
        if (_sourceType == "normal")
        {
            normalButtonSource.Play();
        }
        else if (_sourceType == "positive")
        {
            positiveButtonSource.Play();
        }
    }

    void MuteSound()
    {
        ///to mute sound completely
        audioMixer.GetFloat("master_Volume", out soundValueMaster);
        //audioMixer.GetFloat("music_Volume", out soundValueMusic);
        //audioMixer.GetFloat("sound_Volume", out soundValueSound);
        if (soundValueMaster == -20)
        {
            audioMixer.SetFloat("master_Volume", -80);
        }
        //else if (soundValueMusic == -20)
        //{
        //    audioMixer.SetFloat("music_Volume", -80);
        //}
        //else if (soundValueSound == -20)
        //{
        //    audioMixer.SetFloat("sound_Volume", -80);
        //}
    }
    #endregion

    #region MOUSE/KEYBOARD

    public void SetSensitivity(float _value)
    {
        r_fpCamera.mouseSensitivity = _value;
    }
    #endregion
}
