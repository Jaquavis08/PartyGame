using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName, 3f));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
