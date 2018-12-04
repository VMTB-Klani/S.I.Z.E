using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : Interactablegameobj {

	public override void OnSelcetedObj()
	{
		Destroy(this.gameObject);
	}

	public override string OnViewPoint()
	{
		return base.OnViewPoint();
	}
}
