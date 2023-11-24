using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class VisualEffectButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource audioSource;
    public AudioClip clip;

    [HideInInspector] public Vector3 scaleInBegin;
    public void OnPointerEnter(PointerEventData eventData)
    {
        scaleInBegin = gameObject.transform.localScale;
        gameObject.transform.localScale = scaleInBegin * 1.2f;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        BackSize();
    }

    public void BackSize()
    {
        gameObject.transform.localScale = scaleInBegin;
    }
}
