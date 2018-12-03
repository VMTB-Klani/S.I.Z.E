using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// audio handler, handles audio stuff
/// or stores audio clips/files
/// </summary>
public class AudioHandler : MonoBehaviour
{
    //private//
    [SerializeField] AudioClip[] r_footstepClips;
    [SerializeField] AudioClip[] r_powerUPClips;

    /// <summary>
    /// returns random audio clips
    /// 
    /// for variety/better feeling when moving as EX
    /// </summary>
    /// <returns></returns>
    public AudioClip GetRandomAudioClip()
    {
        return r_footstepClips[Random.Range(0, r_footstepClips.Length)];
    }

    /// <summary>
    /// return audio clip for powerups
    /// which one is chosen in pwUP script to match the right powerUP
    /// </summary>
    /// <param name="_value"></param>
    /// <returns></returns>
    public AudioClip ReturnPowerUPClip(int _value)
    {
        return r_powerUPClips[_value];
    }
}
