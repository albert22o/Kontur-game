using System;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
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

        animator.SetFloat("SpeedX", currentSpeedX);
        animator.SetFloat("SpeedZ", currentSpeedZ);

        lastPosition = transform.position;
    }
}
