using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FinishGameUI : MonoBehaviour
{
    public GameObject FailGamePanel;
    public GameObject SuccessGamePanel;
    public float time = 100;

    private PostProcessVolume processVolume;
    private AudioSource[] audioSources;
    private ColorGrading colorGrading;
    private ChromaticAberration chromaticAberration;
    private GameObject cam;
    public Component[] component;
    private void Start()
    {
        cam = transform.GetChild(0).gameObject;
        processVolume = cam.GetComponent<PostProcessVolume>();
    }
    public void FailGame()
    {
        Obshee();
        processVolume.profile.TryGetSettings(out colorGrading);
        Instantiate(FailGamePanel);
        StartCoroutine(FailGames());
    }

    public void SuccessGame()
    {
        Obshee();
        Instantiate(SuccessGamePanel);
    }

    IEnumerator FailGames()
    {
        while (time > 0)
        {
            for (int i = 0; i < audioSources.Length; i++)
            {
                if(audioSources[i] != null)
                audioSources[i].pitch -= 0.01f;
            }
            if(Time.timeScale >= 0.01)
            {
                Time.timeScale -= 0.01f;
            }
            colorGrading.saturation.value -= 1f;
            time -= 1;
            yield return null;
        }
        Time.timeScale = 0f;
    }

    public void Obshee()
    {
        processVolume.profile.TryGetSettings(out chromaticAberration);
        chromaticAberration.enabled.value = false;
        for (int i = 0; i < component.Length; i++)
        {
            Destroy(component[i]);
        }
        for (int i = 0; i < cam.transform.childCount; i++)
        {
            Destroy(cam.transform.GetChild(i).gameObject);
        }
        Cursor.lockState = CursorLockMode.None;
        audioSources = FindObjectsOfType<AudioSource>();
    }
}
