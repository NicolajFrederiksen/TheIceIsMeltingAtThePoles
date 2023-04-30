using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public string GameScene;
    

    public void PlayGame()
    {
        SceneManager.LoadScene(GameScene);
    }
}
