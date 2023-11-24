using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class MenuEffectsSettings : MonoBehaviour
{
    public PostProcessProfile profile;
    [Header("AmbientOcclusion")]
    [SerializeField] private Slider sliderAmbientOcclusionIntencity;
    [SerializeField] private TextMeshProUGUI ambientOcclusionIntencityText;
    [Header("Bloom")]
    [SerializeField] private Slider sliderBloomIntencity;
    [SerializeField] private TextMeshProUGUI bloomIntencityText;
    [Header("MotionBlur")]
    [SerializeField] private Slider sliderMotionBlurShutterAngle;
    [SerializeField] private TextMeshProUGUI motionBlurShutterAngleText;
    [Header("CromaticAberration")]
    [SerializeField] private Slider sliderChromaticAberrationIntencity;
    [SerializeField] private TextMeshProUGUI chromaticAberrationIntencityText;

    private AmbientOcclusion ambientOcclusion;
    private Bloom bloom;
    private MotionBlur motionBlur;
    private ChromaticAberration chromaticAberration;
    public void Start()
    {
        profile.TryGetSettings(out ambientOcclusion);
        profile.TryGetSettings(out bloom);
        profile.TryGetSettings(out motionBlur);
        profile.TryGetSettings(out chromaticAberration);

        sliderAmbientOcclusionIntencity.value = SettingsValues._ambientOcclusionIntencity;
        ambientOcclusionIntencityText.text = (Mathf.Round(sliderAmbientOcclusionIntencity.value * 10.0f) * 0.1f).ToString();

        sliderBloomIntencity.value = SettingsValues._bloomIntencity;
        bloomIntencityText.text = (Mathf.Round(sliderBloomIntencity.value * 10.0f) * 0.1f).ToString();

        sliderMotionBlurShutterAngle.value = SettingsValues._motionBlurShutterAngle;
        motionBlurShutterAngleText.text = sliderMotionBlurShutterAngle.value.ToString();

        sliderChromaticAberrationIntencity.value = SettingsValues._chromaticAberration;
        chromaticAberrationIntencityText.text = sliderChromaticAberrationIntencity.value.ToString();
    }

    private void Update()
    {
        Debug.Log("WorkingEffectsSettings");
        ChangeEffectsSettings();
    }

    private void ChangeEffectsSettings()
    {
        //Setting effect - Ambient occlusion
        if (SettingsValues._ambientOcclusionIntencity != sliderAmbientOcclusionIntencity.value)
        {
            SettingsValues._ambientOcclusionIntencity = sliderAmbientOcclusionIntencity.value;
            ambientOcclusionIntencityText.text = (Mathf.Round(sliderAmbientOcclusionIntencity.value * 10.0f) * 0.1f).ToString();
            //ambientOcclusion.intensity.value = SettingsValues._ambientOcclusionIntencity;
        }

        //Setting effect - Bloom
        if (SettingsValues._bloomIntencity != sliderBloomIntencity.value)
        {
            SettingsValues._bloomIntencity = sliderBloomIntencity.value;
            bloomIntencityText.text = (Mathf.Round(sliderBloomIntencity.value * 10.0f) * 0.1f).ToString();
            //bloom.intensity.value = SettingsValues._bloomIntencity;
        }

        //Setting effect - Motion blur
        if (SettingsValues._motionBlurShutterAngle != sliderMotionBlurShutterAngle.value)
        {
            SettingsValues._motionBlurShutterAngle = sliderMotionBlurShutterAngle.value;
            motionBlurShutterAngleText.text = sliderMotionBlurShutterAngle.value.ToString();
            //motionBlur.shutterAngle.value = SettingsValues._motionBlurShutterAngle;
        }

        //Setting effect - Chromatic aberration
        if (SettingsValues._chromaticAberration != sliderChromaticAberrationIntencity.value)
        {
            SettingsValues._chromaticAberration = sliderChromaticAberrationIntencity.value;
            chromaticAberrationIntencityText.text = (Mathf.Round(sliderChromaticAberrationIntencity.value * 10.0f) * 0.1f).ToString();
            //chromaticAberration.intensity.value = SettingsValues._chromaticAberration;
        }

    }
}
