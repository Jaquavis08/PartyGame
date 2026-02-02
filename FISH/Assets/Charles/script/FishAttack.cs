using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(PlayerInput), typeof(Animator), typeof(Rigidbody2D))]
public class FishAttack : MonoBehaviour
{
    public float radius;
    public Rigidbody2D rb2d;
    public GameObject parent;
    public GameObject attackPoint;
    public LayerMask players;

    private PlayerInput playerInput;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        if (rb2d == null) rb2d = GetComponent<Rigidbody2D>();
    }

    public void Attack()
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, players);

        foreach (Collider2D playerGameObject in player)
        {
            Debug.Log("Hit Player");
        }
    }

    void Update()
    {
        if (playerInput == null || rb2d == null) return;

        // Use the PlayerInput instance actions directly
        var attackAction = playerInput.actions["Attack"];
        if (attackAction != null && attackAction.WasPerformedThisFrame())
        {
            animator.SetBool("isAttacking", true);
            
        }
    }

    public void EndAttack()
    {
        animator.SetBool("isAttacking", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);

    }

    private void OnAttack()
    {
        Attack();
    }
}