using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    private Button button1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button1 = transform.Find("Exit").GetComponent<Button>();

        button1.onClick.AddListener(() =>
        {
            Quit1();
        });
    }

    public void Quit1()
    {
        Application.Quit();
    }
}