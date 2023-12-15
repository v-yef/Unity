using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    private int _nextLevelNumber;

    private void Start()
    {
        _nextLevelNumber = computeNextLevelNumber(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Scenes/Level_" + _nextLevelNumber);

            Debug.Log("Entered next level portal! Level_" + _nextLevelNumber + " was loaded!");
        }
    }

    private int computeNextLevelNumber(string sceneName)
    {
        int levelNumberPos = sceneName.IndexOf('_');
        int currentLevelNumber = Int32.Parse(sceneName.Substring(levelNumberPos + 1));

        return (currentLevelNumber < 2) ? (currentLevelNumber + 1) : 0;
    }
}