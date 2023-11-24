using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenGameplaySettingsPanel : VisualEffectButton
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject gameplaySettingsPanel;
    [SerializeField] private GameObject effectsSettingsPanel;
    [SerializeField] Image[] buttonColors;
    [SerializeField] Image[] buttonColorsOtherButton;

    [SerializeField] private Color color;
    [SerializeField] private Color returnColor;
    private void OnEnable()
    {
        if (gameplaySettingsPanel.activeSelf)
        {
            for (int i = 0; i < buttonColors.Length; i++)
            {
                buttonColors[i].color = color;
            }
        }
    }
    public void ClickButton()
    {
        if (effectsSettingsPanel.activeSelf || settingsPanel.activeSelf == false)
        {
            settingsPanel.SetActive(true);
            gameplaySettingsPanel.SetActive(true);
            effectsSettingsPanel.SetActive(false);
            for (int i = 0; i < buttonColors.Length; i++)
            {
                buttonColors[i].color = color;
            }
            for (int i = 0; i < buttonColorsOtherButton.Length; i++)
            {
                buttonColorsOtherButton[i].color = returnColor;
            }
        }
        else
        {
            settingsPanel.SetActive(false);
            for (int i = 0; i < buttonColors.Length; i++)
            {
                buttonColors[i].color = returnColor;
            }
        }
    }
}
