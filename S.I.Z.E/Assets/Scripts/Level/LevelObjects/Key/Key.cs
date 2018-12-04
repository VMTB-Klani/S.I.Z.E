using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : InteractibleGameObj
{
	GameManager gameManager;
	public void Awake()
	{
		gameManager = FindObjectOfType<GameManager>();
	}
    public override void OnSelectedObject()
    {
		gameManager.m_CountKey++;
		gameManager.starttime = Time.time;
		gameManager.setNewText = true;
        Destroy(this.gameObject);
    }

    public override string OnViewPoint()
    {
        return base.OnViewPoint();
    }
}
