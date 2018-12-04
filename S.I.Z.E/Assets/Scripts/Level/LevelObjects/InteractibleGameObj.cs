using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleGameObj : MonoBehaviour {

	[SerializeField]
	string m_Describtion;
	public void start()
	{

	}
	public virtual string OnViewPoint()
	{
		return m_Describtion;
	}
	public virtual void OnSelcetedObj()
	{
	}
}
