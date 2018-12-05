using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToWithSizeChange : TeleportTo {

	public override void OnTriggerEnter(Collider _other)
	{
		base.OnTriggerEnter(_other);
		if (_other.gameObject.tag == "Player")
		{
			_other.gameObject.transform.localScale = new Vector3(1, 1, 1);
		}
	}
}
