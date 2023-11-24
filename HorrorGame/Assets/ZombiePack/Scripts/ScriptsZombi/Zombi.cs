using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;
public class Zombi : InGameAgentManager
{
    public AudioClip[] audioClipsAttackZombie;
    public GameObject rightHand;

    private AudioSource audioSourceAttack;
    private GameObject player;
    private float distance;
    private bool attackZombi = false;

    private void Start()
    {
        audioSourceAttack = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        Initialize();
        audioSourceAttack.volume = SettingsValues._volumeValueSoundOfMonsters;
        audioSourceIdleSound.volume = SettingsValues._volumeValueSoundOfMonsters;
        deletedBot = false;
    }

    private void FixedUpdate()
    {
        if (!stopBot && !deletedBot)
        {
            PlayAnimation(3.5f);
            BegRandom();
        }

        if (stopBot && !deletedBot)
        {
            CheckStatusInActiveRagdoll();
        }
    }

    private void BegRandom()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if (attackZombi == false)
        {
            agent.SetDestination(player.transform.position);
            if (distance > 2)
            {
                agent.speed = 3.5f;
            }
            else if (distance <= 2)
            {
                agent.speed = 0;
                attackZombi = true;
                StartCoroutine(ChangeAnimation("Attack", false, 3f));
            }
        }
        else
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 1);
            animator.SetBool("Attack", true);
            if (!rightHand.GetComponent<DamageZombi>())
            {
                rightHand.AddComponent<DamageZombi>();
            }
            if (!rightHand.GetComponent<DamageZombi>())
            {
                rightHand.AddComponent<DamageZombi>();
                rightHand.SetActive(true);
                Destroy(rightHand);
                rightHand.transform.position = new Vector3(0, 0, 0);
            }
        }
    }

    IEnumerator ChangeAnimation(string nameAnimation, bool activate, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(rightHand.GetComponent<DamageZombi>());
        animator.SetBool(nameAnimation, activate);
        attackZombi = false;
    }

    public void PlaySound()
    {
        audioSourceAttack.clip = audioClipsAttackZombie[Random.Range(0, audioClipsAttackZombie.Length)];
        audioSourceAttack.Play();
    }

    public void StopSound()
    {
        audioSourceAttack.clip = null;
        audioSourceAttack.Play();
        agent.stoppingDistance = 0;
        //agent.remainingDistance = 2;
    }
}
