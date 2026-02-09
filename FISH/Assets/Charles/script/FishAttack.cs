using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


public class FishAttack : MonoBehaviour
{
    public float radius;
    public Rigidbody2D rb2d;
    public GameObject parent;
    public GameObject attackPoint;
    public LayerMask players;
    public PlayerInput playerInput;
    [SerializeField] private Animator animator;
    private bool isAttacking = false;
    public bool IsAttacking => isAttacking;

    public void clearattacking()=> isAttacking = false;
    private void Awake()
    {
       
        if (rb2d == null) rb2d = GetComponent<Rigidbody2D>();
    }

    public void Attack()
    {
        
        Collider2D[] player = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, players);
        Debug.Log("Attack is called");
        foreach (Collider2D playerGameObject in player)
        {
            Debug.Log("Hit Player");
            isAttacking = true;
        } 

    }
    
    void Update()
    {
       

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
    
}