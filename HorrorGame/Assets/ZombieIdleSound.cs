using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleSound : MonoBehaviour
{
    public AudioClip[] audioClipsIdleZombie;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClipsIdleZombie[Random.Range(0, audioClipsIdleZombie.Length)];
        audioSource.Play();
        Destroy(gameObject.GetComponent<ZombieIdleSound>());
    }
}
