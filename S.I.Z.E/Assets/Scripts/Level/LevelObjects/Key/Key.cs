﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : InteractibleGameObj
{
    public override void OnSelcetedObj()
    {
        Destroy(this.gameObject);
    }

    public override string OnViewPoint()
    {
        return base.OnViewPoint();
    }
}
