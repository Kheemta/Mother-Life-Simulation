using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehavior : MonoBehaviour
{
    //Transform of the gameobject you want to shake
    private Transform transform;

    //Desired duation of the shake effect
    public float shakeDuration = 0f;

    //A measure of magnitude for the shake. Tweak based on your preference
    public float shakeMagnitude = 0.7f;

    //A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    //The initial position of the gameObject
    Vector3 initialPosition;

    private void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    private void FixedUpdate()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake()
    {
        shakeDuration = 2.0f;
    }
}
