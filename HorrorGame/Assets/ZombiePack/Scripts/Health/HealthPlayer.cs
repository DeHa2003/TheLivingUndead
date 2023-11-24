using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : HealthManager
{
    public Animator bloodUI;
    private void Start()
    {
        healthSlider.maxValue = health;
    }
    public void AttackZombi()
    {
        if (health <= 0)
        {
            gameObject.GetComponent<FinishGameUI>().FailGame();
            StopAllCoroutines();
        }
        else
        {
            bloodUI.SetBool("Attack", true);
            StartCoroutine(OffAnim());
        }
    }

    IEnumerator OffAnim()
    {
        yield return new WaitForSeconds(0.3f);
        bloodUI.SetBool("Attack", false);
    }
}
