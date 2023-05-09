using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{


    public void StartGame()
    {

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

        SceneManager.LoadScene("exit");

    }

    public void GameLevel()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void getBack()
    {
        SceneManager.LoadScene("Menu");
    }


}
