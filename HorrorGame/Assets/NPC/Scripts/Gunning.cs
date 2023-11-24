using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Gunning : InGameAgentManager
{
    public GameObject enemy;
    [Header("Voices")]
    public List<AudioClip> audios = new();
    [Header("Max speed")]
    [Range(0f, 5.4f)]
    public float maxSpeed = 0;
    public float speedRotate;
    public GameObject bulletPref;
    public Transform bulletPos;
    public float speedBullet;
    public float distance;
    public AudioSource audioGunFire;

    private List<GameObject> enemyes;
    private bool attack = true;
    private bool goAway = false;
    private void Start()
    {
        Initialize();
        deletedBot = false;
    }

    GameObject FindZombie()
    {
        float minDistance = Mathf.Infinity;
        enemyes = monstersArray.monsters;//YOUR ENEMY MASSIV
        if(enemyes.Count > 0)
        {
            for (int i = 0; i < enemyes.Count; i++)
            {
                float distance = Vector3.Distance(enemyes[i].transform.position, transform.position);
                if (distance < minDistance)
                {
                    enemy = enemyes[i];
                    minDistance = distance;
                }
            }
            return enemy;
        }
        else
        {
            agent.speed = 0;
            animator.SetBool("Fire", false);
            return null;
        }
    }

    private void Update()
    {
        if (!deletedBot && !stopBot)
        {
            PlayAnimation(5.4f);
            Shooting();
        }

        if (stopBot && !deletedBot)
        {
            CheckStatusInActiveRagdoll();
        }
    }

    private void Shooting()
    {
        if (attack)
        {
            FindZombie();
            if (enemy != null && enemy.CompareTag("Zombi"))
            {
                distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance >= 10)
                {
                    animator.SetBool("Fire", false);
                    agent.speed = maxSpeed;
                    agent.SetDestination(enemy.transform.position);
                }
                else if (distance > 5 && distance < 10)
                {
                    goAway = false;
                    agent.speed = 0;
                    Vector3 direction = (enemy.transform.position - transform.position).normalized;
                    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                    transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * speedRotate);
                    animator.SetBool("Fire", true);
                }
                
                if(distance <= 5)
                {
                    if(goAway == false)
                    {
                        animator.SetBool("Fire", false);
                        if (RandomPoint(out Vector3 pos))
                        {
                            agent.SetDestination(pos);
                            goAway = true;
                        }
                        agent.speed = maxSpeed;
                    }
                }
            }
        }
    }

    //private void CheckPosToRun()
    //{
    //    Vector3 posSpawn = new Vector3(Random.Range(0, 300), 0, Random.Range(0, 300));
    //    if (agent.SetDestination(posSpawn))
    //    {
    //        agent.SetDestination(posSpawn);
    //        goAway = true;
    //    }
    //}

    public void Fire()
    {
        var bullet = Instantiate(bulletPref);
        bullet.transform.position = bulletPos.position;
        bullet.GetComponent<Rigidbody>().velocity = speedBullet * Time.deltaTime * (enemy.transform.position - bulletPos.position + new Vector3(0f, 1.2f, 0f));
        audioGunFire.Play();
    }

    public void GoToObject(Transform obj)
    {
        attack = false;
        animator.SetBool("Fire", false);
        agent.speed = maxSpeed;
        agent.SetDestination(obj.position);
    }

    bool RandomPoint(out Vector3 result)
    {
        Vector3 randomPoint = new Vector3(150, 0, 150) + Random.insideUnitSphere * 150;
        if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}
