using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class ScalePickup : MonoBehaviour
{
    public GameObject playerscore;
    void Start()
    {
        playerscore.GetComponent<float>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            //playerscore=+1; // Increase scale by 0.1 as an example
            Destroy(gameObject) // Destroy the pickup after collecting
            
        }
    }
}