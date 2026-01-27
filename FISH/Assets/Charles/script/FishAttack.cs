using UnityEngine;
using UnityEngine.InputSystem;

public class FishAttack : MonoBehaviour
{
    public float attackRange = 2.0f;
    public Rigidbody2D rb2d;
    public void Attack()
    {
        PlayerInput pI = GetComponent<PlayerInput>();
        GetComponent <Animator>().SetTrigger("Attack");
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput pI = GetComponent<PlayerInput>();
        if (PlayerInput.all[pI.playerIndex].actions["Attack"].WasPerformedThisFrame())
        {
            Vector2 attackDirection = new Vector2(transform.localScale.x, 0).normalized;
            RaycastHit2D hit = Physics2D.Raycast(rb2d.position, attackDirection, attackRange, LayerMask.GetMask("Player"));
            if (hit.collider != null)
            {
                Debug.Log("Hit " + hit.collider.name);
                // Apply damage or effects to the hit player
            }
        }
        Gizmos.DrawWireSphere(rb2d.position + new Vector2(transform.localScale.x * attackRange, 0), 0.1f);
    
    }
}