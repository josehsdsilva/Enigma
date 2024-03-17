using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    string mainScene = "StartingScene";

    public List<string> visited;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this object when loading new scenes
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }

        visited = new();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetBackToStartScene();
        }
    }

    public void InteractWithBear()
    {
        if (!visited.Contains("House"))
        {
            LoadScene("House");
        }
    }
    public void InteractWithBow()
    {
        if (!visited.Contains("Church"))
        {
            LoadScene("Church");
        }
    }
    public void InteractWithDiary()
    {
        if (!visited.Contains("Final"))
        {
            LoadScene("FinalScene");
        }
    }

    public void GetBackToStartScene()
    {
        if(SceneManager.GetActiveScene().name != mainScene)
        {
            LoadScene(mainScene);
        }
    }

    public void LoadNextScene()
    {
        // Get the index of the current active scene
        int currentIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene by incrementing the current scene index
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        if(sceneName != mainScene && !visited.Contains(sceneName))
        {
            visited.Add(sceneName);
        }
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
