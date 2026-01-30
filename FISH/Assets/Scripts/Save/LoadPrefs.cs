using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPrefs : MonoBehaviour
{
    //public TMPro_Text

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Points"))
        {
            float points = PlayerPrefs.GetFloat("Points");
        }
    }
}