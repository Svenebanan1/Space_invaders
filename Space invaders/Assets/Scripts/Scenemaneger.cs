using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemaneger : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void options()
    {

    }
}
