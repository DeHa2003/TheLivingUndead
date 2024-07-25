using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BodyPartCollider : MonoBehaviour, IGetDirectionDamage
{
    [SerializeField] private TwoBoneIKConstraint twoBoneIK;
    [SerializeField] private float blendOutDuration;
    private BodyPart bodyPart;
    public void Initialize(BodyPart bodyPart)
    {
        this.bodyPart = bodyPart;
    }
    public void TakeDamage(Vector3 point, Vector3 direction, float damage)
    {
        //switch (bodyPart)
        //{
        //    case BodyPart.LeftHand:
        //        Debug.Log("попадание в левую руку");
        //        break;

        //    case BodyPart.RightHand:
        //        Debug.Log("попадание в правую руку");
        //        break;

        //    case BodyPart.LeftFoot:
        //        Debug.Log("попадание в левую ногу");
        //        break;

        //    case BodyPart.RightFoot:
        //        Debug.Log("попадание в правую ногу");
        //        break;

        //    case BodyPart.Head:
        //        Debug.Log("попадание в голову");
        //        break;
        //}

        Debug.Log("HJHHJH");

        Vector3 targetPosition = point + direction * 0.7f;
        twoBoneIK.data.target.position = targetPosition;

        StartCoroutine(Test());
    }

    public void TakeDamage(float damage)
    {
        //throw new System.NotImplementedException();
    }

    private IEnumerator Test()
    {
        twoBoneIK.weight = 1;

        float elapsedTime = 0f;

        while(elapsedTime < blendOutDuration)
        {
            elapsedTime += Time.deltaTime;
            twoBoneIK.weight = Mathf.Lerp(1f, 0f, elapsedTime / blendOutDuration);
            yield return null;
        }

        twoBoneIK.weight = 0;
    }
}
