using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : Inteactablegameobj {

	
	public override void OnSelcetedObj()
	{
		Destroy(this.gameObject);
	}
	public override string OnViewPoint()
	{
		return "Press E to collect the key";
	}
}
