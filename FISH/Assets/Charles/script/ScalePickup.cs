using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ScalePickup : MonoBehaviour
{
    public GameObject scale;
    public GameObject playerscore;
    public float ps =1 ;
    public GameObject parent;
    public GameObject ph;
    public GameObject player;
    void Start()
    {
        // UNT0001: The Unity message 'Start' is empty.
        // You can safely remove this method if you don't need it,
        // or leave it as is to avoid UNT0001.
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
        if (other.gameObject.CompareTag("hit") && other.gameObject != ph && other.gameObject != player)
        {
            if (other.gameObject != ph)
            {
                Debug.Log("found hit ");
                
                //other.gameObject.GetComponent<Score>().score =+ ps; // Update the score in the Score component
                if (scale != null)
                {
                    Debug.Log("scale colected ");
                    scale.SetActive(false);
                    
                     scale.transform.SetParent(parent != null ? parent.transform : null);
                    // If you want to access the parent, you can assign it to a variable or use it in logic:
                     Transform scaleParent = scale.transform.parent;
                    
                }
            }
        }
    }
}