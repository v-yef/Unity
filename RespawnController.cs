using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{
    private string _sceneName;

    void Start()
    {
        _sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Scenes/" + _sceneName);

            Debug.Log("Entered respawn zone! " + _sceneName + " was reset!");
        }
    }
}