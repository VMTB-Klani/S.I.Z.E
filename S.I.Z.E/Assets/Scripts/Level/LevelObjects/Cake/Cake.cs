using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : InteractibleGameObj
{
    //private//
    SizeChanger r_SizeChanger;

    private void Awake()
    {

    }

    void Start()
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
        r_SizeChanger.SmallSize();
    }

    public override void OnSelectedObject()
    {
        Destroy(this.gameObject);
    }

    public override string OnViewPointText()
    {
        return base.OnViewPointText();
    }
}
