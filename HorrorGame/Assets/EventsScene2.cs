using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EventsScene2 : MonoBehaviour
{
    [SerializeField] private GameObject zadanie;
    [SerializeField] private GameObject[] npc;
    [SerializeField] private GameObject arrowToObject;
    [SerializeField] private GameObject car;
    [SerializeField] private GameObject me;

    private bool isRunningNPC = false;
    private NavMeshAgent[] navMeshAgents = new NavMeshAgent[2];
    private void Start()
    {
        for (int i = 0; i < npc.Length; i++)
        {
            navMeshAgents[i] = npc[i].GetComponent<NavMeshAgent>();
        }
    }
    private void GoToObjectNPC(GameObject lookingObj, float stopDistance)
    {
        for (int i = 0; i < npc.Length; i++)
        {
            navMeshAgents[i].stoppingDistance = stopDistance;
            npc[i].GetComponent<Gunning>().GoToObject(lookingObj.transform);
        }
    }
    public void GoToMe()
    {
        isRunningNPC = true;
        GoToObjectNPC(me, 1);
    }
    public void GoToCar()
    {
        zadanie.GetComponent<TextMeshProUGUI>().text = "Go to car";
        zadanie.SetActive(true);
        arrowToObject.GetComponent<ArrowLookToObj>().lookingObj = car.transform;
        arrowToObject.SetActive(true);
        GoToObjectNPC(car, 7);
        car.GetComponent<TriggerEvent>().first = true;
    }

    public void GoToEnding()
    {
        SceneManager.LoadScene(6, LoadSceneMode.Single);
    }

    private void Update()
    {
        if (isRunningNPC)
        {
            GoToMe();
            if (navMeshAgents[0].remainingDistance <= navMeshAgents[0].stoppingDistance + 5)
            {
                isRunningNPC = false;
                npc[0].GetComponent<AudioSource>().Play();
                Invoke(nameof(GoToCar), 1);
            }
        }
    }
}
