using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenViborPanel : VisualEffectButton
{
    public GameObject startPanel;
    public GameObject viborPanel;
    public AudioClip audioClipClickSuccess;

    public void OpenPanelVibor()
    {
        gameObject.transform.localScale = scaleInBegin;
        audioSource.clip = audioClipClickSuccess;
        audioSource.Play();
        viborPanel.SetActive(true);
        startPanel.SetActive(false);
    }
}
