using System.Collections;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private bool isHit = false;
    public bool IsHit => isHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("hit"))
        {
            Debug.Log(" true Hit");
            isHit = true;
            var scaleDrop = other.GetComponentInChildren<ScaleDrop>();
            if (scaleDrop != null)
            {
                // Use a public trigger method instead of calling a hidden StartCoroutine overload
                scaleDrop.TriggerDrop();
            }
        }
    }
}
