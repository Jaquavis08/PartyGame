using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class StealOFih : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (TryDestroyOneLabeledChild(other.gameObject) == false)
        {
            Destroy(other.transform.parent.gameObject);
            PointSystem.Instance.Playerscore(other.transform.parent.gameObject, -500);
        }
    }

    private bool TryDestroyOneLabeledChild(GameObject target)
    {
        GameObject parentTransform = target.gameObject;
        Debug.Log("started looking for child");
        if (parentTransform.transform.childCount == 0)
        {
            Debug.Log("no child found");
            return false;
        }
        GameObject child = target.transform.GetChild(0).gameObject;
        Destroy(child.gameObject);
        PointSystem.Instance.Playerscore(target.transform.parent.gameObject, -100);
        return true;
    }
}
