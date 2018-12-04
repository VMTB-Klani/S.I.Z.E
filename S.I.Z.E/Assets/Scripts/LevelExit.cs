using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collision has been detected...");
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Collided with player, loading next scene.");
            LoadNextScene();
        }
    }

    /// <summary>
    /// Load the next scene in the build through it's index.
    /// </summary>
    public void LoadNextScene()
    {
        Debug.Log("Get current Index...");
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Get next scene...");
        SceneManager.LoadScene(currentsceneindex + 1);
    }
}
