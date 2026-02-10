using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScaleDrop : MonoBehaviour
{
    public GameObject sca;
    private Rigidbody2D rb2d;
    void Start()
    {
        // Hide the scale initially
        if (sca != null)
            sca.SetActive(false);

        // Fix: Use Rigidbody2D.constraints to control position freezing
       
        if (rb2d != null)
        {
            rb2d.constraints = RigidbodyConstraints2D.None; // Unfreeze all constraints
        }
    }

    // Public method to start the drop coroutine from another component
    public void TriggerDrop()
    {
        StartCoroutine(DropedScale());
    }

    public IEnumerator DropedScale()
    {
        if (sca != null)
        {
            sca.SetActive(true);
            Debug.Log("Scale dropped and active");
            rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
            Debug.Log("Rigidbody2D constraints set to FreezeAll");
            yield return new WaitForSeconds(10f);
            Debug.Log("10 seconds passed, hiding scale and unfreezing Rigidbody2D");    
            sca.SetActive(false);

            rb2d.constraints = RigidbodyConstraints2D.None;
        }
    }
}
