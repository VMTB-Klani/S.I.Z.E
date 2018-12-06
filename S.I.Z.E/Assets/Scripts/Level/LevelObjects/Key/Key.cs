using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : InteractibleGameObj
{
    //public//
    public AudioSource source;

    //private//
    GameManager gameManager;

    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        //source = GetComponent<AudioSource>();
    }
    public override void OnSelectedObject()
    {
        gameManager.m_CountKey++;
        gameManager.startTime = Time.time;
        gameManager.setNewText = true;
        source.Play();
        Destroy(this.gameObject);
    }

    public override string OnViewPointText()
    {
        return base.OnViewPointText();
    }
}
