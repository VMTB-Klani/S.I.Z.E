using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FP_CharacterController : MonoBehaviour
{
    //public//
    [HideInInspector] public CharacterController r_characterController;

    [HideInInspector] public float speed = 5.1f;

    [HideInInspector] public float jumpSpeed = 7.0f;///height
    [HideInInspector] public float gravity = 24.0f;///drag/pull to the ground

    //private//
    float midAirMultiplier = 0.9f;

    bool isJumping;

    Vector3 moveDirection = Vector3.zero;

    ///raycast hit for interacting with objects
    RaycastHit hit;

    ///pickup range, for raycast
    int pickupRange = 2;

    ///references
    AudioHandler r_audioHandler;
    FP_Camera r_fpCamera;
    UIHandler r_uiHandler;

    [SerializeField] AudioSource r_footstepSource;

    private void Awake()
    {
        r_audioHandler = FindObjectOfType<AudioHandler>();
        r_characterController = GetComponent<CharacterController>();
        r_fpCamera = GetComponentInChildren<FP_Camera>();
        r_uiHandler = FindObjectOfType<UIHandler>();
    }

    void Update()
    {
        DoMovement();
        InteractWithObjects();
    }

    /// <summary>
    /// play random footstep sounds for the player
    /// only when on the ground and when moving fast enough
    /// 
    /// sound volume and pitch is based on sprinting/crouching and normal moving
    /// to give a more ->immersive<- feeling (battlefield 5 LUL)
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayFootstepSound()
    {
        if (r_characterController.velocity.magnitude >= 1f && !r_footstepSource.isPlaying)
        {
            AudioClip clip = r_audioHandler.GetRandomAudioClip();
            r_footstepSource.PlayOneShot(clip);
            r_footstepSource.volume = Random.Range(0.25f, 0.3f);
            r_footstepSource.pitch = Random.Range(0.85f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void DoMovement()
    {
        if (r_characterController.isGrounded)
        {
            isJumping = false;

            ///if grounded, accept movement input --> for groundMovement!!
            ///normalize for same diagonal movement speed as normal straigh forward etc. speed
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
            moveDirection.Normalize();

            ///rotate towards the move direction
            moveDirection = transform.rotation * moveDirection;

            ///multiply by speed offset to have decent movement speed
            moveDirection *= speed;

            ///jump on input
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                isJumping = true;
            }

            StartCoroutine(PlayFootstepSound());
        }
        else
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            ///combine both inputs to normalize them later
            ///needed because you cant "moveDirection.Normalize();" without influencing Y
            Vector3 combinedInput = new Vector3(x, 0, y);

            ///in air, accept movement input --> for airMovement!!
            ///move with the normalized X and Z for same movement speed diagonal
            ///moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), moveDirection.y, Input.GetAxisRaw("Vertical"));
            moveDirection = new Vector3(combinedInput.normalized.x, moveDirection.y, combinedInput.normalized.z);

            ///rotate towards the move direction
            moveDirection = transform.rotation * moveDirection;

            ///multiply by speed offset to have decent movement speed
            moveDirection.x *= speed;
            moveDirection.z *= speed;

            ///when jumping apply airSpeed for slower movement while midAir
            ///also lets the play fall correctly when he just fell of something
            if (isJumping)
            {
                moveDirection.x *= midAirMultiplier;
                moveDirection.z *= midAirMultiplier;
            }
        }

        ///apply gravity, drags the char down to the (ground or where ever etc.) 
        moveDirection.y -= gravity * Time.deltaTime;

        ///move the char
        r_characterController.Move(moveDirection * Time.deltaTime);
    }

    void InteractWithObjects()
    {
        if (Physics.Raycast(r_fpCamera.gameObject.transform.position, r_fpCamera.gameObject.transform.forward, out hit, pickupRange))
        {
            if (hit.transform.gameObject.tag == "Interactible")
            {
                InteractibleGameObj inter = hit.transform.gameObject.GetComponent(typeof(InteractibleGameObj)) as InteractibleGameObj;

                r_uiHandler.infoText.text = inter.OnViewPoint();

                if (Input.GetKey(KeyCode.E))
                {
                    if (inter != null)
                        inter.OnSelectedObject();
                }
            }
            else
            {
                r_uiHandler.infoText.text = "";
            }
        }
        else
        {
            r_uiHandler.infoText.text = "";
        }
    }
}