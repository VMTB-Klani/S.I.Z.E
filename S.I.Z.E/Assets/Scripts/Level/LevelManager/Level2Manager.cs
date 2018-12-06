using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    [SerializeField]
    InteractibleGameObj m_ViewMark;
    public bool m_AktivatePuzzleTile;
    public bool m_DeaktivatePuzzleWall1;
    [SerializeField]
    GameObject m_PuzzleWall1;
    [SerializeField]
    GameObject m_Player;
    [SerializeField] List<GameObject> m_PuzzleTilesToAnable;
    Vector3 m_PuzzleWall1OriPos;
    // Update is called once per frame
    void Start()
    {
        m_PuzzleWall1OriPos = m_PuzzleWall1.transform.position;
    }
    void Update()
    {
        if (m_AktivatePuzzleTile)
        {
            foreach (GameObject PuzzleTile in m_PuzzleTilesToAnable)
            {
                PuzzleTile.SetActive(true);
            }
        }
        if (m_ViewMark.m_LookAt)
        {
            m_PuzzleWall1.transform.position = new Vector3(m_PuzzleWall1OriPos.x, m_PuzzleWall1OriPos.y + 5, m_PuzzleWall1OriPos.z);
        }
        else
        {
            m_Player = FindObjectOfType<CharacterController>().gameObject;
            if (!m_DeaktivatePuzzleWall1)
                m_PuzzleWall1.transform.position = m_PuzzleWall1OriPos;
            else
            {

                if (m_Player.transform.rotation.y > 0.9f || m_Player.transform.rotation.y < -0.9f)
                    m_PuzzleWall1.transform.position = m_PuzzleWall1OriPos;
            }
        }


    }
}
