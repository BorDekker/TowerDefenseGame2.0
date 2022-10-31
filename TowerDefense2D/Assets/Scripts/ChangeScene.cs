using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Changing Scene");
    }

    public void Option()
    {
        Debug.Log("Option click");
    }

    public void GoBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("Going back");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Changing Scene");
    }

    public void WannaTryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("This is where the fun begins");
    }

    public void IfDiedBackToMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Debug.Log("Going back to map");
    }

    public void IfWonBackToMap()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        Debug.Log("Going back to map");
    }
}
