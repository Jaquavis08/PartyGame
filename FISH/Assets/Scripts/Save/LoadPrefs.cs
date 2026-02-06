using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPrefs : MonoBehaviour
{
    private float points;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Points"))
        {
            points = PlayerPrefs.GetFloat("Points");
        }
        else
        {
            PlayerPrefs.SetFloat("Points", 0f);
            points = 0f;
            Debug.Log("No points found in PlayerPrefs.");
        }
    }
}