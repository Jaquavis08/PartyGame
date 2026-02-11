using UnityEngine;

public class HowToPlayEnable : MonoBehaviour
{
    [SerializeField] private GameObject howToPlayPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        howToPlayPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enable()
    {
        howToPlayPanel.SetActive(true);
    }
    public void Disable()
    {
        howToPlayPanel.SetActive(false);
    }
}
