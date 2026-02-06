using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScaleDrop : MonoBehaviour
{
    
    public GameObject scale;
    public FishAttack fishAttack;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scale.SetActive(false); // Initially hide the scale
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine((IEnumerator)DropedScale());
    }
    public IEnumerable DropedScale()
    {
     if (fishAttack.isHit == true )
        {
            
            scale.SetActive(true); // Show the scale when hit
            yield return new WaitForSeconds(5f); // Keep the scale visible for 5 seconds
        }
    }
   
}
