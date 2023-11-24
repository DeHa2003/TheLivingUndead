using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingsInMenu : VisualEffectButton
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject start;
    [SerializeField] private AudioClip clickSound;
    public void OpenMenuSettings()
    {
        BackSize();
        audioSource.clip = clickSound;
        audioSource.Play();
        menu.SetActive(true);
        start.SetActive(false);
    }
}
