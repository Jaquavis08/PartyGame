using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public class ScalePickup : MonoBehaviour
{
    public GameObject scale;
    public GameObject playerscore;
    public float ps;
    public Rigidbody2D rb2d;

    void Start()
    {
        
    }

    void Update()
    {
          //  if (playerscore != null)
            //{
              //  var scoreComponent = playerscore.GetComponent<Score>();
                //if (scoreComponent != null)
                //{
                 //   ps = scoreComponent.score; // Update ps with the current score
               // }
      //  }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger ");
        if (other.gameObject.CompareTag("hit"))
        {
            
            Debug.Log("found hit ");
            ps += 1f; // Increase scale by 1 as an example
            if (scale != null)
            {
                Debug.Log("scale colected ");
                scale.SetActive(false);
               // Destroy the pickup after collectin
                scale.transform.position = new Vector3(parent, hit.y, hit.z); // Move it far away to effectively "destroy" it
            }
        }
    }
}