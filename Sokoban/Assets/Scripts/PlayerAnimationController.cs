using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private Vector3 lastPosition;
    private float currentSpeed;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, lastPosition);
        currentSpeed = distance / Time.deltaTime;

        animator.SetFloat("Speed", currentSpeed);

        lastPosition = transform.position;
    }
}
