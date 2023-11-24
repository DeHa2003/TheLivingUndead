using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.root.gameObject.CompareTag("Zombi"))
        {
            GameObject obj = collision.gameObject.transform.root.gameObject;
            if (obj.GetComponent<Zombi>())
            {
                var bot = collision.gameObject.transform.root.GetComponent<Zombi>();
                if (bot.stopBot == false)
                {
                    bot.stopBot = true;
                    bot.RagdollActivate();
                }
            }

            if (obj.GetComponent<PolzZombi>())
            {
                var bot = collision.gameObject.transform.root.GetComponent<PolzZombi>();
                if (bot.stopBot == false)
                {
                    bot.stopBot = true;
                    bot.RagdollActivate();
                }
            }
        }
    }
}
