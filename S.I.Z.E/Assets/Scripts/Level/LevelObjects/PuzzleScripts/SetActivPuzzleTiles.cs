using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActivPuzzleTiles : MonoBehaviour
{
    void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == "Player")
        {
            Level2Manager Manager = FindObjectOfType<Level2Manager>();
            Manager.m_AktivatePuzzleTile = true;
        }
    }
}
