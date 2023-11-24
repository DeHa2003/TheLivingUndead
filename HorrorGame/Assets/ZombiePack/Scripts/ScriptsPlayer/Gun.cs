using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI kolBulletsUI;
    [Header("Sound effects")]
    public AudioClip fireClip;
    public AudioClip perezaryad;
    [Header("Gun components")]
    public GameObject bullet;
    public float firespeed;

    private Transform spawnPoint;
    private Camera cam;
    private AudioSource gunSound;
    private bool activePricel = false;
    private bool perezaryadka = false;
    private Animator animator;
    private int kolBullets = 50;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void Start()
    {
        spawnPoint = transform.GetChild(0).transform;
        cam = transform.parent.gameObject.GetComponent<Camera>();
        gunSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GunFire();
    }

    private void GunFire()
    {
        if (!perezaryadka)
        {
            if (Input.GetMouseButtonDown(1))
            {
                 OnPricel();
                 activePricel = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                OffPricel();
                activePricel = false;
            }

            if (activePricel)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    PlaySound(fireClip, true);
                    animator.SetBool("Fire", true);
                }
                if (Input.GetMouseButton(0))
                {
                    SpawnBullets();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    animator.SetBool("Fire", false);
                    gunSound.Stop();
                }

            }
        }
    }

    public void SpawnBullets()
    {
        if(kolBullets >= 1)
        {
            kolBullets -= 1;
            kolBulletsUI.text = kolBullets.ToString();
            GameObject game = Instantiate(bullet);
            game.transform.position = spawnPoint.position;
            game.GetComponent<Rigidbody>().velocity = spawnPoint.forward * firespeed;
        }
        else
        {
            OnPerezaryad();
        }
    }

    private void OnPricel()
    {
        cam.fieldOfView = 30;
        animator.SetBool("Pricel", true);
    }
    private void OffPricel()
    {
        gunSound.Stop();
        cam.fieldOfView = 50;
        animator.SetBool("Fire", false);
        animator.SetBool("Pricel", false);
    }

    private void OnPerezaryad()
    {
        perezaryadka = true;
        kolBullets = 80;
        PlaySound(perezaryad, false);
        animator.SetBool("Fire", false);
        Invoke(nameof(OffPerezaryad), 1.3f);
    }

    private void OffPerezaryad()
    {
        kolBulletsUI.text = kolBullets.ToString();
        perezaryadka = false;
        if (Input.GetMouseButton(0))
        {
            PlaySound(fireClip, true);
            animator.SetBool("Fire", true);
        }
        else
        {
            OffPricel();
        }
    }

    public void OffAnimationInPause()
    {
        OffPricel();
    }
    private void PlaySound(AudioClip audioClip, bool looping)
    {
        gunSound.loop = looping;
        gunSound.clip = audioClip;
        gunSound.Play();
    }
}
