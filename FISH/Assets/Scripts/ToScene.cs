using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour
{
    private Button button1;


    public void LoadSceneByName(string sceneName)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName, 3f));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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
      StartCoroutine(QuitAfterDelay(0, 3f));
    }

    public IEnumerator QuitAfterDelay(int quit, float delays)
    {
        yield return new WaitForSeconds(delays);
        Application.Quit(quit);
    }
}
