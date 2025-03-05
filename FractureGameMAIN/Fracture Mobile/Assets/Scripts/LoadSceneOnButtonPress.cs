using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnButtonPress : MonoBehaviour
{
    public Button yourButton; // Assign this in the Inspector
    public string sceneName; // Assign the name of the scene to load in the Inspector

    void Start()
    {
        yourButton.onClick.AddListener(LoadScene);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}