using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    //public//
    public GameObject cam;

    //private//
    FP_CharacterController r_characterController;

    private void Awake()
    {
        r_characterController = GetComponent<FP_CharacterController>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            SmallSize();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            NormalSize();
        }
    }

    public void SmallSize()
    {
        r_characterController.speed = 2.1f;
        r_characterController.jumpSpeed = 5.0f;
        gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void NormalSize()
    {
        r_characterController.speed = 5.1f;
        r_characterController.jumpSpeed = 7.0f;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
