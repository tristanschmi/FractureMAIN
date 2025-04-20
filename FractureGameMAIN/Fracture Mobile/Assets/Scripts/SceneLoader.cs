using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName; // Scene name to load, set in the Inspector

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is not set or is empty!");
        }
    }

    public void LoadScene(string customSceneName)
    {
        if (!string.IsNullOrEmpty(customSceneName))
        {
            SceneManager.LoadScene(customSceneName);
        }
        else
        {
            Debug.LogWarning("Custom scene name is not set or is empty!");
        }
    }
}