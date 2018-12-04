using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTo2 : MonoBehaviour
{
    public int count;

    [SerializeField] Vector3 teleportCord;

    public void Start()
    {
        count = 0;
    }

    public void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == "Player")
        {
            count++;
            if (count >= 2)
                _other.gameObject.transform.position += teleportCord;

        }
        Debug.Log(count);
    }
}
