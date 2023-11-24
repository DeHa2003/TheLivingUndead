using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenPanelMenuGAME : VisualEffectButton
{
    public Button button;
    public GameObject settingsPanel;
    public TextMeshProUGUI textZadanieInGame;
    public TextMeshProUGUI textZadanieInMenu;
    public GameObject buttonExitButton;
    public Animator animator;
    public Gun gun;
    private AudioSource audioS;
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    public void OpenPanelMenu()
    {
        settingsPanel.SetActive(true);
        textZadanieInMenu.text = textZadanieInGame.text;
        audioS.Play();
        gun.OffAnimationInPause();
        gun.enabled = false;
        gameObject.SetActive(false);
        BackSize();
        animator.SetBool("OpenMenu", true);
        Invoke(nameof(StopTime), 0.5f);
    }

    public void StopTime()
    {
        buttonExitButton.SetActive(true);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            scaleInBegin = gameObject.transform.localScale;
            OpenPanelMenu();
        }
    }
}
