using System;
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
   
    void Start()
    {
        // Hide the scale initially
        if (sca != null)
            sca.SetActive(false);
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
            yield return new WaitForSeconds(10f);
            sca.SetActive(false);
        }
    }
}
