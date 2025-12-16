using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private void Start()
    {
        var playerController = GetComponent<PlayerController>();
        playerController.OnMoveStart += () => HandleMove(true);
        playerController.OnMoveEnd += () => HandleMove(false);
    }

    private void HandleMove(bool isMoving)
    {
        animator.SetBool("isMoving", isMoving);
    }
}
