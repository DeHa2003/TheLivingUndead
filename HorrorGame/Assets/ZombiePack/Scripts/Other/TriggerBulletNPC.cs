using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBulletNPC : MonoBehaviour
{
    private GameObject obj;

    private bool first = true;
    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (first)
        {
            obj = collision.gameObject.transform.root.gameObject;
            if (obj.CompareTag("Zombi"))
            {
                if (obj.GetComponent<Zombi>())
                {
                    if (obj.GetComponent<Zombi>().deletedBot == false)
                    {
                        obj.GetComponent<HealthZombi>().GetDamage(Random.Range(10, 50));
                        obj.GetComponent<Zombi>().Destroy();
                    }
                }

                if (obj.GetComponent<PolzZombi>())
                {
                    if (obj.GetComponent<PolzZombi>().deletedBot == false)
                    {
                        obj.GetComponent<HealthZombi>().GetDamage(Random.Range(20, 60));
                        obj.GetComponent<PolzZombi>().Destroy();
                    }
                }

                if (obj.GetComponent<Zombi_ManyPLAYERS>())
                {
                    if (obj.GetComponent<Zombi_ManyPLAYERS>().deletedBot == false)
                    {
                        obj.GetComponent<HealthZombi>().GetDamage(Random.Range(20, 60));
                        obj.GetComponent<Zombi_ManyPLAYERS>().Destroy();
                    }
                }
                Destroy(gameObject);
            }
            first = false;
        }
    }
}
