using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ScalePickup : MonoBehaviour
{
    public GameObject scale;
    private GameObject pointStuff;
    public float ps;
    public GameObject parent;
    public GameObject hitbox;
    public GameObject player;
    
   
    void Start()
    {
        pointStuff = GameObject.Find("pointStuff");
        hitbox = GameObject.Find("hitbox");
        player = GameObject.Find("Player");
        parent = GameObject.Find("parent");
    }
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger ");
        Debug.Log("found hit ");

        CollectScale(other);
    }
    
    public void CollectScale(Collider2D other)
    {
        // Ignore collisions from the parent object or any of its children.
        if (parent != null)
        {
            
             if (other.transform.root.gameObject == parent) return;
        }
        if (scale.activeSelf == true)
            ps += 1;
        Debug.Log("scale collected ");
        scale.SetActive(false);
        scale.transform.position = parent.transform.position;
    }
}