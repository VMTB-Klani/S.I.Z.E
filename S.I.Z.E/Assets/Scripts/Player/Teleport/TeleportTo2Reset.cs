using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTo2Reset : MonoBehaviour
{
    [SerializeField] bool teleportSide;

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == "Player")
        {
            TeleportTo2 Tele = GetComponentInParent(typeof(TeleportTo2)) as TeleportTo2;
            if (teleportSide)
            {

                Tele.count++;
            }
            else
            {
                Tele.count = -1;
            }
        }
    }
}
