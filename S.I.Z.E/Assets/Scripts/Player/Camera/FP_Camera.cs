using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// camera script for FPS games
/// lets the user look around freely, but clamps at 90 and -90 degrees
/// can only look around when the cursor is locked and hidden
/// the player gameobject moves along the look direction
/// </summary>
public class FP_Camera : MonoBehaviour
{
    //public//
    ///MouseLook
    [HideInInspector] public float mouseSensitivity;

    //private//
    ///GameObject of the character or "body"
    GameObject characterGO;

    float yaw = 0.022f; ///The Yaw of the Camera.
    float pitch = 0.022f; ///The Pitch of the Camera.
    Vector2 pitchMinMax = new Vector2(-90, 90); ///clamp camera x and y

    void Start()
    {
        characterGO = transform.parent.gameObject;

        mouseSensitivity = 2;
    }

    void Update()
    {
        ///When the cursor is locked, rotate the Camera.
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            RotateCamera();
        }
    }

    /// <summary>
    /// Rotate the camera and player
    /// </summary>
    private void RotateCamera()
    {
        //Get mouse input
        float inputMouseX = Input.GetAxisRaw("Mouse X");
        float inputMouseY = Input.GetAxisRaw("Mouse Y");

        ///Check if there is any mouse input
        if (inputMouseX != 0 || inputMouseY != 0)
        {
            ///Camera rotation
            yaw += mouseSensitivity * inputMouseX;
            pitch -= mouseSensitivity * inputMouseY;

            ///Clamp rotation
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

            ///Rotate Camera Y
            ///transform.localRotation = Quaternion.AngleAxis(pitch, Vector3.right);
            transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);

            ///Rotate Camera X
            ///characterGJ.transform.localRotation = Quaternion.AngleAxis(yaw, characterGJ.transform.up);
            characterGO.transform.localEulerAngles = new Vector3(0.0f, yaw, 0.0f);
        }
    }
}


