using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit(string)
    {

    }
}
