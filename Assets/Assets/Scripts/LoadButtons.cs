using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButtons : MonoBehaviour
{
    // this script is for moving between the screens
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
