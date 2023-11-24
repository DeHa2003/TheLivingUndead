using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySettingsScript : MonoBehaviour
{
    [Header("VolumeMusic")]
    [SerializeField] private AudioSource[] backgroundSound = new AudioSource[3];
    [SerializeField] private Slider sliderBackgroundSound;
    [SerializeField] private TextMeshProUGUI backgroundSoundVolumeText;
    [Header("VolumeMonsters")]
    [SerializeField] private MonstersArray monstersArray;
    [SerializeField] private List<AudioSource> allSoundsMonsters;
    [SerializeField] private Slider sliderAllSoundsMonsters;
    [SerializeField] private TextMeshProUGUI volumeMonstersText;
    [Header("VolumeGun")]
    [SerializeField] private AudioSource[] allSoundsGuns;
    [SerializeField] private Slider sliderAllSoundsGuns;
    [SerializeField] private TextMeshProUGUI volumeGunsText;
    [Header("SpeedMousesMoving")]
    [SerializeField] private PlayerMoveScript playerMoveScript;
    [SerializeField] private Slider sliderSpeedMouseH;
    [SerializeField] private TextMeshProUGUI speedMouseHText;
    [SerializeField] private Slider sliderSpeedMouseV;
    [SerializeField] private TextMeshProUGUI speedMouseVText;

    public void InitializeSettings()
    {
        sliderBackgroundSound.value = SettingsValues._volumeBackgroundSound;
        backgroundSoundVolumeText.text = (Mathf.Round(sliderBackgroundSound.value * 10.0f) * 0.1f).ToString();
        for (int i = 0; i < backgroundSound.Length; i++)
        {
            backgroundSound[i].volume = SettingsValues._volumeBackgroundSound;
        }

        sliderAllSoundsMonsters.value = SettingsValues._volumeValueSoundOfMonsters;
        volumeMonstersText.text = (Mathf.Round(sliderAllSoundsMonsters.value * 10.0f) * 0.1f).ToString();

        sliderAllSoundsGuns.value = SettingsValues._volumeSoundsGun;
        volumeGunsText.text = (Mathf.Round(sliderAllSoundsGuns.value * 10.0f) * 0.1f).ToString();
        for (int i = 0; i < allSoundsGuns.Length; i++)
        {
            allSoundsGuns[i].volume = SettingsValues._volumeSoundsGun;
        }

        sliderSpeedMouseH.value = SettingsValues._speedMouseH;
        speedMouseHText.text = (Mathf.Round(sliderSpeedMouseH.value * 10.0f) * 0.1f).ToString();
        playerMoveScript.speedH = SettingsValues._speedMouseH;

        sliderSpeedMouseV.value = SettingsValues._speedMouseV;
        speedMouseVText.text = (Mathf.Round(sliderSpeedMouseV.value * 10.0f) * 0.1f).ToString();
        playerMoveScript.speedV = SettingsValues._speedMouseV;
    }

    private void OnEnable()
    {
        for (int i = 0; i < monstersArray.monsters.Count; i++)
        {
            allSoundsMonsters.Add(monstersArray.monsters[i].GetComponent<AudioSource>());
            allSoundsMonsters.Add(monstersArray.monsters[i].transform.GetChild(1).GetComponent<AudioSource>());
        }
    }

    private void OnDisable()
    {
        allSoundsMonsters.Clear();
    }

    private void Update()
    {
        Debug.Log("WorkingGameplaySettings");
        ChangeGameplaySettings();
    }

    private void ChangeGameplaySettings()
    {
        //Setting background sound volume
        if (SettingsValues._volumeBackgroundSound != sliderBackgroundSound.value)
        {
            SettingsValues._volumeBackgroundSound = sliderBackgroundSound.value;
            backgroundSoundVolumeText.text = (Mathf.Round(sliderBackgroundSound.value * 10.0f) * 0.1f).ToString();
            for (int i = 0; i < backgroundSound.Length; i++)
            {
                backgroundSound[i].volume = SettingsValues._volumeBackgroundSound;
            }
        }

        //Setting monsters sound volume
        if (SettingsValues._volumeValueSoundOfMonsters != sliderAllSoundsMonsters.value)
        {
            SettingsValues._volumeValueSoundOfMonsters = sliderAllSoundsMonsters.value;
            volumeMonstersText.text = (Mathf.Round(sliderAllSoundsMonsters.value * 10.0f) * 0.1f).ToString();
            for (int i = 0; i < allSoundsMonsters.Count; i++)
            {
                allSoundsMonsters[i].volume = SettingsValues._volumeValueSoundOfMonsters;
            }
        }

        //Settings gun sound volume
        if (SettingsValues._volumeSoundsGun != sliderAllSoundsGuns.value)
        {
            SettingsValues._volumeSoundsGun = sliderAllSoundsGuns.value;
            volumeGunsText.text = (Mathf.Round(sliderAllSoundsGuns.value * 10.0f) * 0.1f).ToString();
            for (int i = 0; i < allSoundsGuns.Length; i++)
            {
                allSoundsGuns[i].volume = SettingsValues._volumeSoundsGun;
            }
        }

        //Setting speed move mouseX
        if(SettingsValues._speedMouseH != sliderSpeedMouseH.value)
        {
            SettingsValues._speedMouseH = sliderSpeedMouseH.value;
            speedMouseHText.text = (Mathf.Round(sliderSpeedMouseH.value * 10.0f) * 0.1f).ToString();
            playerMoveScript.speedH = sliderSpeedMouseH.value;
        }

        if (SettingsValues._speedMouseV != sliderSpeedMouseV.value)
        {
            SettingsValues._speedMouseV = sliderSpeedMouseV.value;
            speedMouseVText.text = (Mathf.Round(sliderSpeedMouseV.value * 10.0f) * 0.1f).ToString();
            playerMoveScript.speedV = sliderSpeedMouseV.value;
        }
    }
}
