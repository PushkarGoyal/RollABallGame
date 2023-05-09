using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public Button l1;
    public void seenManager(int a)
    {
        SceneManager.LoadScene(a);
    }

    private void Start()
    {
        l1.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene(1);
        });
    }
}
