using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStartPanel : VisualEffectButton
{
    public GameObject startPanel;
    public GameObject viborPanel;
    public AudioClip audioClipClickFail;

    public void OpenPanelStart()
    {
        gameObject.transform.localScale = scaleInBegin;
        audioSource.clip = audioClipClickFail;
        audioSource.Play();
        viborPanel.SetActive(false);
        startPanel.SetActive(true);
    }
}
