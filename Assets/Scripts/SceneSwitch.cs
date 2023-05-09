using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    public int level = 1;

    public void SceneSwitcher()
    {
        Time.timeScale = 1;  // unpausing the game paused at end of last scene
        SceneManager.LoadScene(level + 1);
    }
}
