using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
   static int shopScene = 0;

    public static void LoadShopScene()
    {
        SceneManager.LoadScene (shopScene);
    }

    public static void LoadNextScene()
    {

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene < SceneManager.sceneCountInBuildSettings)
        SceneManager.LoadScene(currentScene+1);
    }

    public static void LoadPreviousScene()
    {
        int currentScene = SceneManager.GetActiveScene ().buildIndex;

        if (currentScene > 0)
            SceneManager.LoadScene (currentScene-1);
    }

    public static void LoadScene(int index)
    {
        if (index >= 0 && index < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(index);
    }

}
