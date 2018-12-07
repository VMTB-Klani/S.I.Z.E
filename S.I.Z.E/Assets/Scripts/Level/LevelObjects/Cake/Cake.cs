using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : InteractibleGameObj
{
    //public//
    public AudioSource source;

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
        r_SizeChanger.SmallSize();
        source.Play();
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
