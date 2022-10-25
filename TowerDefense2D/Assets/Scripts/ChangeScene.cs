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

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
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
}
