using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class ScalePickup : MonoBehaviour
{
    private GameObject scale;
    public float playerscore =0 ;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("hit"))
        {
            playerscore=+1; // Increase scale by 0.1 as an example
            scale.SetActive(false);// Destroy the pickup after collecting
            
            
        }
    }
}