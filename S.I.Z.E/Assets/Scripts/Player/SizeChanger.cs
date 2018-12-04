using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    FP_CharacterController r_CC;

    bool toggle;

    private void Awake()
    {
        r_CC = GetComponent<FP_CharacterController>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeSize();
        }
    }

    void ChangeSize()
    {
        toggle = !toggle;
        if (toggle)
        {
            r_CC.r_characterController.height = 0.2f;
        }
        else
        {
            r_CC.r_characterController.height = 1.8f;
        }
    }
}
