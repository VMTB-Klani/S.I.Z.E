using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToWithSizeChange : TeleportTo
{
    SizeChanger r_sizeChanger;

    private void Awake()
    {

    }

    private void Update()
    {
        if (r_sizeChanger == null)
        {
            r_sizeChanger = FindObjectOfType<SizeChanger>();
        }
    }

    public override void OnTriggerEnter(Collider _other)
    {
        base.OnTriggerEnter(_other);
        if (_other.gameObject.tag == "Player")
        {
            r_sizeChanger.NormalSize();
        }
    }
}
