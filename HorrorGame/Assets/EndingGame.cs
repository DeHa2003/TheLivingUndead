using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndingGame : MonoBehaviour
{
    [SerializeField] private Animator endingAnim;
    [SerializeField] private GameObject endingPanel;
    [SerializeField] private float timeToActivateEnding;
    [SerializeField] private float timeToActivateCamera;
    [SerializeField] private float timeToPlayAudio;
    [SerializeField] private float timeToInstanceSuccessPanel;

    private bool changePitch = false;
    private bool reverseSound = true;

    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        StartCoroutine(EndingCutScene());
    }
    private IEnumerator EndingCutScene()
    {
        yield return new WaitForSeconds(timeToActivateEnding);
        gameObject.GetComponent<VideoPlayer>().Play();
        yield return new WaitForSeconds(timeToActivateCamera);
        gameObject.GetComponent<VideoPlayer>().targetCamera = Camera.main;
        yield return new WaitForSeconds(timeToPlayAudio);
        StartCoroutine(PlaySound());
        yield return new WaitForSeconds(timeToInstanceSuccessPanel);
        Destroy(gameObject.GetComponent<VideoPlayer>());
        changePitch = true;
        endingPanel.SetActive(true);

    }
    IEnumerator PlaySound()
    {
        audioSource.time = 58.4f;  //54.2
        audioSource.Play();
        while (audioSource.volume <= 1)
        {
            audioSource.volume += 0.001f;
            yield return null;
        }
    }

    private void Update()
    {
        if (!audioSource.isPlaying && changePitch)
        {
            if (reverseSound)
            {
                reverseSound = false;
                endingAnim.SetBool("Reverse", true);
                audioSource.time = 275f;
                audioSource.pitch = Random.Range(-1.3f, -0.7f);
            }
            else
            {
                reverseSound = true;
                endingAnim.SetBool("Reverse", false);
                audioSource.time = 1;
                audioSource.pitch = Random.Range(0.7f, 1.3f);
            }
            audioSource.Play();
        }
    }
}
