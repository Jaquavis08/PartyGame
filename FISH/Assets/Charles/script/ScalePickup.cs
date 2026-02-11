using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ScalePickup : MonoBehaviour
{
    public GameObject scale;
    private GameObject pointStuff;
    public float ps =1 ;
    public GameObject parent;
    public GameObject ph;
    public GameObject player;
    
   
    void start()
    {
        pointStuff = GameObject.Find("pointStuff");
        
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

                CollectScale(other);
            }
        }
    }
    
    public void CollectScale(Collider2D other)
    {
        //other.gameObject.GetComponent<Score>().score =+ ps; // Update the score in the Score component
        if (other.gameObject != ph && other.gameObject != player)
        {
            Debug.Log("scale colected ");
            scale.SetActive(false);

            scale.transform.SetParent(parent != null ? parent.transform : null);
            // If you want to access the parent, you can assign it to a variable or use it in logic:
            Transform scaleParent = scale.transform.parent;

        }
    }
}