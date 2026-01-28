using UnityEngine;
using UnityEngine.InputSystem;

public class FishAttack : MonoBehaviour
{
    public float attackRange = 300.0f;
    public Rigidbody2D rb2d;
    public void Attack()
    {
        PlayerInput pI = GetComponent<PlayerInput>();
        GetComponent <Animator>().SetTrigger("Attack");
        
    }

    void Update()
    {
        PlayerInput pI = GetComponent<PlayerInput>();
        if (PlayerInput.all[pI.playerIndex].actions["Attack"].WasPerformedThisFrame())
        {
            Vector2 attackDirection = new Vector2(transform.localScale.x, 0).normalized;
            RaycastHit2D hit = Physics2D.Raycast(rb2d.position, attackDirection, attackRange, LayerMask.GetMask("Player"));
            if (hit.collider != null)
            {
                Debug.Log("Hit");
                // Apply damage or effects to the hit player

            }
        }
        Gizmos.DrawWireSphere(rb2d.position + new Vector2(transform.localScale.x * attackRange, 0), 0.1f);
    
    }
    private void OnAttack(InputValue inputValue)
    {
        Attack();
    }
}