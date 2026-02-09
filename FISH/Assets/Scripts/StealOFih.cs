using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StealOFih : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        TryDestroyOneLabeledChild(other.gameObject);
    }

    private bool TryDestroyOneLabeledChild(GameObject target)
    {
        GameObject parentTransform = target.gameObject;
        Debug.Log("started looking for child");
        GameObject child = target.transform.GetChild(0).gameObject;
        Destroy(child.gameObject);
        //PointSystem.Instance.Playerscore(target.pa, 1);
        return false;
    }
}
