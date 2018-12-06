using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleGameObj : MonoBehaviour
{
    [SerializeField] string m_Description;
	public bool m_LookAt;
	public void Start()
    {

    }

    public virtual string OnViewPointText()
    {
        return m_Description;
    }

    public virtual void OnSelectedObject()
    {

    }

	public virtual void  OnViewPoint()
	{
		
	}
}
