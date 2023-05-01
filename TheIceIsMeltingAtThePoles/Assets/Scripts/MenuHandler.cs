using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    public string GameScene;
    private string totalPoints;
    public GameObject StartScene;
    public GameObject HelpScene;
   
    public TMP_Text points;

    public void Start()
    {
        if (points != null)
        {
            setPoints();
        }
    }


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

    public void PlayAgain()
    {
        SceneManager.LoadScene("IntroScene");
        
    }

    public void setPoints()
    {
        totalPoints = PlayerPrefs.GetString("points");
        points.text = totalPoints;

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
