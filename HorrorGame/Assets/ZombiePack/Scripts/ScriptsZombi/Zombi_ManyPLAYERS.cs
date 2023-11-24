using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi_ManyPLAYERS : InGameAgentManager
{
    public AudioClip[] audioClipsAttackZombie;
    public GameObject rightHand;

    private AudioSource audioS;
    private GameObject player;
    private float distance;
    private bool attackZombi = false;

    private void Start()
    {
        audioS = gameObject.GetComponent<AudioSource>();
        Initialize();
        deletedBot = false;
    }

    private void Player()
    {
        float minDistance = Mathf.Infinity;
        for (int i = 0; i < players.Length; i++)
        {
            float distance = Vector3.Distance(players[i].transform.position, transform.position);
            if (distance < minDistance)
            {
                player = players[i];
                minDistance = distance;
            }
        }
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
        if (attackZombi == false)
        {
            Player();
            distance = Vector3.Distance(player.transform.position, transform.position);
            agent.SetDestination(player.transform.position);
            if (distance > 2)
            {
                attackZombi = false;
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
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5);
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
        audioS.clip = audioClipsAttackZombie[Random.Range(0, audioClipsAttackZombie.Length)];
        audioS.Play();
    }
}
