using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : InteractibleGameObj
{
    //private//
    SizeChanger r_SizeChanger;

    private void Awake()
    {

    }

    void Update()
    {
        if (r_SizeChanger == null)
        {
            r_SizeChanger = FindObjectOfType<SizeChanger>();
        }
    }

    private void OnDisable()
    {
        r_SizeChanger.NormalSize();
    }

    public override void OnSelectedObject()
    {
        Destroy(this.gameObject);
    }

    public override string OnViewPoint()
    {
        return base.OnViewPoint();
    }
}
