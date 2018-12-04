using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTo2 : MonoBehaviour {
	[SerializeField]
	Vector3 Teleportcord;
	public int count;
	public void Start()
	{
		count = 0;
	}
	public void OnTriggerEnter(Collider _other)
	{
		
		if (_other.gameObject.tag == "Player")
		{
			count++;
			if(count >= 2)
				_other.gameObject.transform.position += Teleportcord;

		}
		Debug.Log(count);
	}
}
