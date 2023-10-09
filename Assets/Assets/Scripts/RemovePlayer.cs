using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemovePlayer : MonoBehaviour
{
    private void Awake()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        Scene scene = SceneManager.GetActiveScene();
        string sceneDeath = "Death";

        // prevents unnecessary player objects or camera scripts related to the player
        // inside the main menu
        if (sceneIndex == 0)
        {
            foreach (PlayerController obj in FindObjectsOfType<PlayerController>())
            {
                Debug.Log("Destroyed " + obj.gameObject);
                Destroy(obj.gameObject);
            }
            foreach (CameraController obj in FindObjectsOfType<CameraController>())
            {
                Debug.Log("Destroyed " + obj.gameObject);
                Destroy(obj.gameObject);
            }
        }

        // create same thing for Death screen
        if (scene.name == sceneDeath)
        {
            foreach (CameraController obj in FindObjectsOfType<CameraController>())
            {
                Debug.Log("Destroyed " + obj.gameObject);
                Destroy(obj.gameObject);
            }
        }

    }
    void Start()
    {
        
    }
}
