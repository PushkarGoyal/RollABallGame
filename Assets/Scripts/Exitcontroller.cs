using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exitcontroller : MonoBehaviour
{


    public void yesCall()
    {

        Application.Quit();


    }


    public void noCall()
    {

        SceneManager.LoadScene("Menu");

    }
}
