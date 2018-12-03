using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : Inteactablegameobj {

	public override void OnSelcetedObj()
	{
		Destroy(this.gameObject);
	}
}
