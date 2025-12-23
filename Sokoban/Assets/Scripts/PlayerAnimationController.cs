using System;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField, Range(0f, 1f)]
    private float animationDampTime = 0.1f;

    private Vector3 lastPosition;
    private float currentSpeedX;
    private float currentSpeedZ;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        float distanceX = lastPosition.x - transform.position.x;
        float distanceZ = lastPosition.z - transform.position.z;

        currentSpeedX = distanceX / Time.deltaTime;
        currentSpeedZ = distanceZ / Time.deltaTime;

        animator.SetFloat("SpeedX", currentSpeedX, animationDampTime, Time.deltaTime);
        animator.SetFloat("SpeedZ", currentSpeedZ, animationDampTime, Time.deltaTime);

        lastPosition = transform.position;
    }
}