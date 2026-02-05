using UnityEngine;

public class StealOFih : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Tag of objects that will be affected when contacting this object")]
    private string targetTag = "Target";

    [SerializeField]
    [Tooltip("If true uses OnTriggerEnter2D; if false, uses OnCollisionEnter2D")]
    private bool useTrigger = true;

    [SerializeField]
    [Tooltip("If true attempt to destroy one labeled child (fih1..fih10); if false, destroy the contacted GameObject itself")]
    private bool destroyChildren = true;

    [SerializeField]
    [Tooltip("Prefix for labeled children to remove (e.g. 'fih' to match 'fih1'..'fih10')")]
    private string labelPrefix = "fih";

    [SerializeField]
    [Tooltip("Number of labeled children (maximum index). Will check indices 1..labelCount")]
    private int labelCount = 10;

    private int nextLabelIndex = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!useTrigger || other == null || other.gameObject == null)
        {
            return;
        }

        if (!other.CompareTag(targetTag))
        {
            return;
        }

        if (destroyChildren)
        {
            TryDestroyOneLabeledChild(other.gameObject);
            return;
        }

        Destroy(other.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (useTrigger || collision == null || collision.gameObject == null)
        {
            return;
        }

        if (!collision.gameObject.CompareTag(targetTag))
        {
            return;
        }

        if (destroyChildren)
        {
            TryDestroyOneLabeledChild(collision.gameObject);
            return;
        }

        Destroy(collision.gameObject);
    }

    private bool TryDestroyOneLabeledChild(GameObject target)
    {
        if (target == null || string.IsNullOrEmpty(labelPrefix) || labelCount <= 0)
        {
            return false;
        }

        Transform parentTransform = target.transform;

        for (int attempt = 0; attempt < labelCount; attempt++)
        {
            int index = ((nextLabelIndex - 1 + attempt) % labelCount) + 1;
            string childName = labelPrefix + index.ToString();
            Transform child = parentTransform.Find(childName);
            if (child != null && child.gameObject != null)
            {
                Destroy(child.gameObject);
                nextLabelIndex = (index % labelCount) + 1;
                return true;
            }
        }

        return false;
    }
}
