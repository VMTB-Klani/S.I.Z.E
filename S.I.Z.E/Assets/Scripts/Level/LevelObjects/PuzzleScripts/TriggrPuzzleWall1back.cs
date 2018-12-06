using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggrPuzzleWall1back : MonoBehaviour {
	Level2Manager GameMan;
	void Start()
	{
		GameMan = FindObjectOfType<Level2Manager>();
	}
	public virtual void OnTriggerEnter(Collider _other)
	{
		GameMan.m_DeaktivatePuzzleWall1 = true;
	}
}
