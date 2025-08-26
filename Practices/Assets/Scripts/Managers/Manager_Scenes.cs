using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Scenes : MonoBehaviour
{
    private static Manager_Scenes instance;

    public static Manager_Scenes Instance => instance;

    private int currentScene = 0;
    private int previousScene = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeActiveScene()
    {
        previousScene = currentScene;
        currentScene++;

        if (currentScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentScene);
            Debug.Log("New scene loaded: " + currentScene);
        }
        else
        {
            currentScene = 0;
            SceneManager.LoadScene(currentScene);
            Debug.Log("Out of bounds, returning to scene: " + currentScene);
        }
    }
}