using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelMenuGAME : VisualEffectButton
{
    public GameObject buttonStartButton;
    public GameObject settingsPanel;
    public Animator animator;
    public Gun gun;
    private AudioSource audioS;
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    public void ClosePanelMenu()
    {
        Time.timeScale = 1;
        audioS.Play();
        gun.enabled = true;
        gameObject.SetActive(false);
        BackSize();
        animator.SetBool("OpenMenu", false);
        Invoke(nameof(ContinueTime), 0.5f);
    }

    public void ContinueTime()
    {
        settingsPanel.SetActive(false);
        buttonStartButton.SetActive(true);
    }
}
