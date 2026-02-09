using UnityEngine;

public class AttackArea : MonoBehaviour
{

    private bool isHit = false;
    public bool IsHit => isHit;
    private FishAttack  fishAttack;

    public void ClearHit() => isHit = false;

    void Start()
    {
        // Adjust to where AttackArea lives (same object, child, or parent)
        fishAttack = GetComponentInParent<FishAttack>();
        if (fishAttack == null)
            Debug.LogWarning("AttackArea not found on this GameObject or its parent.");
    }
   
    void Update()
    {
        if (fishAttack != null && fishAttack.IsAttack)
        {
            Debug.Log("Detected hit from AttackArea - handle it here.");
            // Handle hit once, then clear the flag:
            fishAttack.clearattacking();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("hit") && fishAttack.IsAttack == true)
        {
            Debug.Log("Hit");
            isHit = true;
        }
    }
}
