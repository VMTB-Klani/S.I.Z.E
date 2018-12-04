using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleGameObj : MonoBehaviour
{
    [SerializeField] string m_Description;

    public void Start()
    {

    }

    public virtual string OnViewPoint()
    {
        return m_Description;
    }

    public virtual void OnSelectedObject()
    {

    }
}
