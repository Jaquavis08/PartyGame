using UnityEngine;

public class StealOFih : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Tag of objects that will be destroyed when contacting this object.")]
    private string targetTag = "Target";

    [SerializeField]
    [Tooltip("If true, uses OnTriggerEnter2D; if false, uses OnCollisionEnter2D.")]
    private bool useTrigger = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!useTrigger || other == null)
        {
            return;
        }

        if (other.CompareTag(targetTag))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (useTrigger || collision == null || collision.gameObject == null)
        {
            return;
        }

        if (collision.gameObject.CompareTag(targetTag))
        {
            Destroy(collision.gameObject);
        }
    }
}
