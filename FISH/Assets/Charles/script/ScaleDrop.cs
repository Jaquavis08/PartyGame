using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScaleDrop : MonoBehaviour
{
    
    public GameObject sca;
    public GameObject player;
    public AttackArea AttackArea;
    public Rigidbody2D prb2d;
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
     private AttackArea attackArea;

    void Start()
    {
        // Adjust to where AttackArea lives (same object, child, or parent)
        attackArea = player.GetComponentInChildren<AttackArea>();
        if (attackArea == null)
            Debug.LogWarning("AttackArea not found on this GameObject or its children.");
    
    
        sca.SetActive(false); // Initially hide the scale
        AttackArea = FindObjectOfType<AttackArea>();

    }

    // Update is called once per frame
    void Update()
    {
        if (sca.active == false)
        {
            sca.transform.position = prb2d.position; // Move the player to the position of the scale
        }

       StartCoroutine((IEnumerator)DropedScale());
    }
    public IEnumerable DropedScale()
    {
        Debug.Log("it runnes it"); 
        if (AttackArea.IsHit == true)
        {   
            Debug.Log("cheese");
            sca.SetActive(true); // Show the scale when hit
            yield return new WaitForSeconds(5f); // Keep the scale visible for 5 seconds
                sca.SetActive(false); // Hide the scale after 5 seconds
               
        }
    }
   
}
