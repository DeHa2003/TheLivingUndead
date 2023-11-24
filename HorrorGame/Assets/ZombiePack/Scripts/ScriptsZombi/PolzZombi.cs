using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolzZombi : InGameAgentManager
{
    public GameObject rightHand;

    private AudioSource audioSourceAttack;
    private GameObject player;
    private float distance;
    private bool attackZombi = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSourceAttack = gameObject.GetComponent<AudioSource>();
        Initialize();
        audioSourceAttack.volume = SettingsValues._volumeValueSoundOfMonsters;
        audioSourceIdleSound.volume = SettingsValues._volumeValueSoundOfMonsters;
        deletedBot = false;
    }

    private void FixedUpdate()
    {
        if (!stopBot && !deletedBot)
        {
            //PlayAnimation(3.5f);
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
            if (distance > 1.8f)
            {
                agent.speed = 0.3f;
            }
            else if (distance <= 1.8f)
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
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10);
            animator.SetBool("Attack", true);
            if (!rightHand.GetComponent<DamageZombi>())
            {
                rightHand.AddComponent<DamageZombi>();
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
        audioSourceAttack.Play();
    }
}
