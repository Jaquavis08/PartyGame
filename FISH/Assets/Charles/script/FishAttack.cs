using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(PlayerInput), typeof(Animator), typeof(Rigidbody2D))]
public class FishAttack : MonoBehaviour
{
    public float attackRange = 300.0f;
    public Rigidbody2D rb2d;
    public GameObject parent;

    private PlayerInput playerInput;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        OnDrawGizmos();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        if (rb2d == null) rb2d = GetComponent<Rigidbody2D>();
    }

    public void Attack()
    {
        Debug.Log("attacked");
        animator.SetTrigger("attacked");
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

    private void OnDrawGizmos()
    {
        if (rb2d == null)
        {
            return;
        }
        Debug.Log("Drawing Gizmos");
        Gizmos.color = Color.red;
        Vector2 spherePos = rb2d.position + new Vector2(Mathf.Sign(transform.localScale.x) * attackRange, 0f);
        Gizmos.DrawWireSphere((Vector3)spherePos, 25f);
    }

    private void OnAttack()
    {
        Attack();
    }
}