using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOnMouseOver : MonoBehaviour
{
    [SerializeField]
    private Vector3 finalScaleMultiplier = new Vector3(1.2f, 1.1f, 1.0f);
    [SerializeField]
    private AnimationCurve animationCurve;

    bool IsMouseOver = false;
    Vector3 initScale, currentScale, finalScale;

    bool isAnimating = false;

    Coroutine co = null;

    // Start is called before the first frame update
    void Start()
    {
        initScale = transform.localScale;
        finalScale = new Vector3(initScale.x * finalScaleMultiplier.x, initScale.y * finalScaleMultiplier.y, initScale.z * finalScaleMultiplier.z);
    }

    private void OnMouseEnter()
    {
        Grow(true);
    }

    private void OnMouseExit()
    {
        Grow(false);
    }

    IEnumerator AnimateGrow()
    {
        float elapsed = 0.0f;
        isAnimating = true;
        while (isAnimating)
        {
            if (IsMouseOver)
                transform.localScale = Vector3.Lerp(currentScale, finalScale, animationCurve.Evaluate(elapsed));
            else
                transform.localScale = Vector3.Lerp(currentScale, initScale, animationCurve.Evaluate(elapsed));

            elapsed += Time.deltaTime;

            if (elapsed >= animationCurve[animationCurve.length -1].time)
            {
                isAnimating = false;
                if (IsMouseOver)
                    transform.localScale = finalScale;
                else
                    transform.localScale = initScale;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    public void Grow(bool isMouseOver)
    {
        IsMouseOver = isMouseOver;
        if (isAnimating)
        {
            return;
        }

        if (co != null)
        {
            StopCoroutine(co);
        }

        currentScale = transform.localScale;

        co = StartCoroutine(AnimateGrow());
    }

    IEnumerator AnimatedGrow()
    {
        yield return new WaitForEndOfFrame();
    }

}
