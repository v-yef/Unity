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
        //SceneManager.LoadScene();
    }

    public void Settings()
    {
        //SceneManager.LoadScene();
    }

    public void About()
    {
        //SceneManager.LoadScene();
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}