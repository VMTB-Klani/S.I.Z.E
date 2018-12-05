using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTo : MonoBehaviour
{
    [SerializeField] Vector3 Teleportcord;
	[SerializeField] bool TeleportToWorldspace;
    public virtual void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == "Player")
        {
			if (TeleportToWorldspace)
			{
				_other.gameObject.transform.position = Teleportcord;
			}
			else
			{
				_other.gameObject.transform.position += Teleportcord;
			}
        }
    }
}
