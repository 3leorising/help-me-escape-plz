using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Debug.Log("Loading next level...");
            
            Destroy(collision.gameObject, .5f);

            foreach (CameraController obj in FindObjectsOfType<CameraController>())
            {
                Debug.Log("Destroyed " + obj + " bcuz lvl up");
                Destroy(obj);
            }

            Invoke("NextLevel", 1f);

        }
            
    }

    void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
