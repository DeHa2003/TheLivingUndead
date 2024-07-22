using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponView : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private AudioClip clipFire;
    [SerializeField] private AudioClip clipReload;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Transform rightHand;

    private SimpleShoot weapon;
    public void SetWeaponData(WeaponData weaponData)
    {
        if(weapon != null)
        {
            Destroy(weapon.gameObject);
        }

        weapon = Instantiate(weaponData.weaponPrefab, rightHand);
        weapon.transform.localPosition = weaponData.weaponPosition;
        weapon.transform.localEulerAngles = weaponData.weaponRotation;
    }

    public void Fire()
    {
        audioSource.PlayOneShot(clipFire);

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Instantiate(effect, hit.point, Quaternion.identity);
            weapon.Shoot();
        }
    }

    public void StartReload()
    {
        audioSource.clip = clipReload;
        audioSource.Play();
    }

    public void EndReload()
    {
        if (audioSource.clip == clipReload && audioSource.isPlaying)
            audioSource.Stop();
    }

    public void StartAim()
    {

    }

    public void EndAim()
    {

    }

    public GameObject spawnParticle()
    {
        GameObject particles = (GameObject)Instantiate(effect);
        particles.transform.position = new Vector3(0, particles.transform.position.y, 0);
#if UNITY_3_5
			particles.SetActiveRecursively(true);
#else
        particles.SetActive(true);
        //			for(int i = 0; i < particles.transform.childCount; i++)
        //				particles.transform.GetChild(i).gameObject.SetActive(true);
#endif

        //if (particles.name.StartsWith("WFX_MF"))
        //{
        //    particles.transform.parent = ParticleExamples[exampleIndex].transform.parent;
        //    particles.transform.localPosition = ParticleExamples[exampleIndex].transform.localPosition;
        //    particles.transform.localRotation = ParticleExamples[exampleIndex].transform.localRotation;
        //}
        //else if (particles.name.Contains("Hole"))
        //{
        //    particles.transform.parent = bulletholes.transform;
        //}

        ParticleSystem ps = particles.GetComponent<ParticleSystem>();
#if UNITY_5_5_OR_NEWER
        if (ps != null)
        {
            var main = ps.main;
            if (main.loop)
            {
                ps.gameObject.AddComponent<CFX_AutoStopLoopedEffect>();
                ps.gameObject.AddComponent<CFX_AutoDestructShuriken>();
            }
        }
#else
		if(ps != null && ps.loop)
		{
			ps.gameObject.AddComponent<CFX_AutoStopLoopedEffect>();
			ps.gameObject.AddComponent<CFX_AutoDestructShuriken>();
		}
#endif


        return particles;
    }
}
