using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour {

	public bool m_AktivatePuzzleTile;
	[SerializeField] List<GameObject> m_PuzzleTilesToAnable;
	// Update is called once per frame
	void Update () {
		if(m_AktivatePuzzleTile)
		{
			foreach(GameObject PuzzleTile in m_PuzzleTilesToAnable)
			{
				PuzzleTile.SetActive(true);
			}
		}
	}
}
