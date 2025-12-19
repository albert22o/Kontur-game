using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private void Start()
    {
        var playerController = GetComponent<PlayerController>();
        playerController.OnMoveStart += () => HandleMove(1);
        playerController.OnMoveEnd += () => HandleMove(0);
    }

    private void HandleMove(float speed)
    {
        animator.SetFloat("Speed", speed);
    }
}
