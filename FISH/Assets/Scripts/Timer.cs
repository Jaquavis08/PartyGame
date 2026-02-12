using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public float gameTime;
    public Image tankShelf;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        tankShelf.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime - Time.time;
        if(time <= 0.001)
        {
            Debug.Log("Time's up!");
            tankShelf.enabled = true;

        }
        else
        {
            timerSlider.value = time;
        }
    }
}
