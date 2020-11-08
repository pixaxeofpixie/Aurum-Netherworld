using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene (sceneName);
    }
    public void ExitGame()
    {
        Application.Quit ();
    }
}
