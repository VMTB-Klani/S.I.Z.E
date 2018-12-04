using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTo : MonoBehaviour {

	[SerializeField]
	Vector3 Teleportcord;

	public void OnTriggerEnter(Collider _other)
	{
		if(_other.gameObject.tag == "Player")
		{
			_other.gameObject.transform.position += Teleportcord; 
		}
	}
}
