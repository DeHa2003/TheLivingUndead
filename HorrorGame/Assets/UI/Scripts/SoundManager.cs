using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public void PlaySound(AudioSource audioSource, AudioClip audioClip, float volume, float spatialBlend)
    {
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.spatialBlend = spatialBlend;
        audioSource.Play();
    }
}
