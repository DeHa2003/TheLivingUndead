using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BodyPartCollider : MonoBehaviour, IGetDirectionDamage
{
    [SerializeField] private BodyPartConfig config;
    [SerializeField] private TwoBoneIKConstraint twoBoneIK;
    [SerializeField] private float blendOutDuration;

    private ColliderSignalsListener signalListener;
    private IEnumerator reloadDirection;

    public void Initialize(ColliderSignalsListener signalListener)
    {
        this.signalListener = signalListener;
    }

    public void TakeDirection(Vector3 point, Vector3 direction)
    {
        signalListener?.TakeDirection(point, direction);

        ActivateReloadDirection(point, direction);
    }

    public void TakeDamage(float damage)
    {
        //signalListener?.TakeChanceFall()
        signalListener?.TakeDamage(damage * config.DamageMultiplayer);
    }

    private void ActivateReloadDirection(Vector3 point, Vector3 direction)
    {
        Vector3 targetPosition = point + direction * 0.7f;
        twoBoneIK.data.target.position = targetPosition;

        if (reloadDirection != null)
            StopCoroutine(reloadDirection);

        StartCoroutine(reloadDirection = ReloadDirection_Coroutine());
    }

    private IEnumerator ReloadDirection_Coroutine()
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
