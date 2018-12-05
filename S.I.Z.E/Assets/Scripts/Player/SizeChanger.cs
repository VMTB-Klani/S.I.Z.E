using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{
    //public//
    public GameObject cam;

    //private//
    FP_CharacterController r_CC;

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
            SmallSize();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            NormalSize();
        }
    }

    public void SmallSize()
    {
        //r_CC.r_characterController.height = 0;
        //cam.transform.position -= new Vector3(0, 0.5f, 0);
        gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void NormalSize()
    {
        //r_CC.r_characterController.height = 1.8f;
        //cam.transform.position += new Vector3(0, 0.5f, 0);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
