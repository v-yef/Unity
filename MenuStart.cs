using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void ChooseLevel()
    {
        SceneManager.LoadScene("ChooseLevel");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void About()
    {
        SceneManager.LoadScene("About");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Level_0");
    }

    public void LoadLevel_1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void LoadLevel_2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void Exit()
    {
        Application.Quit();
    }
}