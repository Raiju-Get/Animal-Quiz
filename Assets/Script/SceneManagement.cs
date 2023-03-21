using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
  public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        ResetTime();
        SceneManager.LoadScene(currentScene+1);
    }

    public void ReloadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        ResetTime();
        SceneManager.LoadScene(currentScene);
    }

    public void LoadHome()
    {
        ResetTime();
        SceneManager.LoadScene(0);
       
    }

    private void ResetTime()
    {
        Time.timeScale = 1.0f;
    }
}
