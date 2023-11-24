using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class InGameAgentManager : MonoBehaviour
{
    [HideInInspector] HealthZombi healthZombi;
    [HideInInspector] public Animator animator;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public AudioSource audioSource;
    [HideInInspector] public List<Rigidbody> rigidbodies;
    [HideInInspector] public List<Collider> colliders;
    [HideInInspector] public List<CharacterJoint> joints;
    [HideInInspector] public GameObject skelet;
    [HideInInspector] public float sec = 2;
    [HideInInspector] public bool deletedBot = false;
    [HideInInspector] public bool stopBot = false;
    [HideInInspector] public int kolBulletFire = 0;
    [HideInInspector] public AudioSource audioSourceIdleSound;
    [HideInInspector] public KillCount killCount;
    [HideInInspector] public MonstersArray monstersArray;
    [HideInInspector] public GameObject[] players;
    public GameObject item;
    public void Initialize()
    {
        players = GameObject.FindGameObjectWithTag("PlayersManager").GetComponent<Players>().players;
        monstersArray = GameObject.FindGameObjectWithTag("MonstersArray").GetComponent<MonstersArray>();
        if(gameObject.tag != "MyNPC")
        {
            monstersArray.monsters.Add(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        killCount = GameObject.Find("Zombies").GetComponent<KillCount>();
        healthZombi = GetComponent<HealthZombi>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        skelet = transform.GetChild(1).gameObject;
        audioSourceIdleSound = skelet.GetComponent<AudioSource>();
        //audioSourceIdleSound.time = Random.Range(1, 20);
        foreach (Rigidbody rigidbody in transform.GetChild(1).GetComponentsInChildren<Rigidbody>())
        {
            rigidbodies.Add(rigidbody);
        }
        foreach (CharacterJoint joint in transform.GetChild(1).GetComponentsInChildren<CharacterJoint>())
        {
            joints.Add(joint);
        }
        foreach (Collider collider in transform.GetChild(1).GetComponentsInChildren<Collider>())
        {
            colliders.Add(collider);
        }
    }

    private void OnDestroy()
    {
        monstersArray.monsters.Remove(gameObject);
    }
    public void RagdollActivate()
    {
        animator.enabled = false;
        agent.speed = 0;

        if (deletedBot)
        {
            for (int i = 0; i < rigidbodies.Count; i++)
            {
                rigidbodies[i].isKinematic = false;
            }
        }

        if (stopBot)
        {
            for (int i = 0; i < rigidbodies.Count; i++)
            {
                if (item != null && rigidbodies[i] != item.GetComponent<Rigidbody>())
                {
                    rigidbodies[i].isKinematic = false;
                }
                else if (item == null) { rigidbodies[i].isKinematic = false; }
            }
        }
    }
    public void PlayAnimation(float interval)
    {
        animator.SetFloat("Move", agent.velocity.magnitude / interval);
    }
    public void RagdollDiactivate()
    {
        animator.enabled = true;
        for (int i = 0; i < rigidbodies.Count; i++)
        {
            rigidbodies[i].isKinematic = true;
        }
    }
    public void CheckStatusInActiveRagdoll()
    {
        if (skelet.GetComponent<Rigidbody>().velocity.magnitude <= 0.03f)
        {
            stopBot = false;
            skelet.transform.parent = null;
            gameObject.transform.position = skelet.transform.position;
            skelet.transform.parent = gameObject.transform;
            RagdollDiactivate();
        }

    }
    public void Destroy()
    {
        int health = healthZombi.health;

        if (health <= 0)
        {
            tag = "DestroyedBot";
            deletedBot = true;
            StartCoroutine(DestroyBot());
        }
    }
    public IEnumerator DestroyBot()
    {
        RagdollActivate();
        if (item != null)
        {
            item.transform.parent = null;
        }
        Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(audioSource);
        Destroy(audioSourceIdleSound);
        killCount.killCountZombies += 1;
        yield return new WaitForSeconds(3);
        Destroy(gameObject.GetComponent<Collider>());
        for (int i = 0; i < joints.Count; i++)
        {
            Destroy(joints[i]);
        }
        for (int i = 0; i < rigidbodies.Count; i++)
        {
            Destroy(rigidbodies[i]);
        }
        for (int i = 0; i < colliders.Count; i++)
        {
            Destroy(colliders[i]);
        }
        Destroy(agent);
        Destroy(animator);
        Destroy(healthZombi);
        Destroy(this);
    }
}
