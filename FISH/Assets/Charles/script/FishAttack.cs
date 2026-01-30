using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(PlayerInput), typeof(Animator), typeof(Rigidbody2D))]
public class FishAttack : MonoBehaviour
{
    public float attackRange = 100.0f;
    public Rigidbody2D rb2d;
    public GameObject parent;

    private PlayerInput playerInput;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        OnDrawGizmosSelected();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        if (rb2d == null) rb2d = GetComponent<Rigidbody2D>();
    }

    public void Attack()
    {
        Debug.Log("attacked");
        animator.SetTrigger("Attack");
    }

    void Update()
    {
        if (playerInput == null || rb2d == null) return;

        // Use the PlayerInput instance actions directly
        var attackAction = playerInput.actions["Attack"];
        if (attackAction != null && attackAction.WasPerformedThisFrame())
        {
            Vector2 attackDirection = new Vector2(Mathf.Sign(transform.localScale.x), 0f).normalized;
            RaycastHit2D hit = Physics2D.Raycast(rb2d.position, attackDirection, attackRange, LayerMask.GetMask("Player"));
            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.collider.name);
                // Apply damage or effects to the hit player
                Debug.Log("attacked");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (rb2d == null) return;
        Vector2 spherePos = rb2d.position + new Vector2(Mathf.Sign(transform.localScale.x) * attackRange, 0f);
        Gizmos.DrawWireSphere(spherePos, 0.1f);
    }

    private void OnAttack()
    {
         Debug.Log("attacked");
        Attack();
    }
}