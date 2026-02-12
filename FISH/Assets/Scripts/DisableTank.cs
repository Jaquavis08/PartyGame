using UnityEngine;
using UnityEngine.UI;

public class DisableTank : MonoBehaviour
{
    public Image tank;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tank = GetComponent<Image>();
        tank.enabled = false;
        
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
