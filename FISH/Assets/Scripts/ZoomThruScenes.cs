using UnityEngine;

public class ZoomThruScenes : MonoBehaviour
{
    public Animator zoomOut;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ZoomTanks()
    {
        zoomOut.SetBool("zoomOut", true);
    }
}
