using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public string GameScene;
    public GameObject StartScene;
    public GameObject HelpScene;



    public void PlayGame()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void HelpCanvas()
    {
        StartScene.SetActive(false);
        HelpScene.SetActive(true);
    }
    public void StartCanvas()
    {
        StartScene.SetActive(true);
        HelpScene.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
