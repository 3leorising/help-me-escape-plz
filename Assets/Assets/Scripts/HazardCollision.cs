using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardCollision : MonoBehaviour
{
    public bool canInstaKill = false;

    float yield = 2f;
    public string DeathScreen = "Death";

    public AudioClip deathSFX;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.FindObjectOfType<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            CameraShake.reference.ShakeCamera();

            if(canInstaKill)
            {
                audioSource.PlayOneShot(deathSFX);
                Destroy(collision.gameObject);

                foreach (CameraController obj in FindObjectsOfType<CameraController>())
                {
                    Debug.Log("Destroyed " + obj + " bcuz u died");
                    Destroy(obj);
                }

                //Invoke("RestartLevel", yield);
                Invoke("Death", yield);
            }
        }
            
    }

    // this function exists for testing hazards + death
    // not meant to actual gameplay
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // this function should be used for proper gameplay
    void Death()
    {
        SceneManager.LoadScene(DeathScreen);
    }
}
