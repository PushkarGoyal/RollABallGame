using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{

    public Animator startAnm;
    public Animator exitAnm;
    public Animator levelAnm;
    public Animator LevelPanelAnm;
    public Animator backAnm;

    public void openMenu()
    {
        startAnm.SetBool("isHidden", false);
        exitAnm.SetBool("IsHidden", false);
        levelAnm.SetBool("IsHidden", false);

    }

    public void closeMenu()
    {

        LevelPanelAnm.SetBool("IsHidden", true);
        backAnm.SetBool("IsHidden", true);
        startAnm.SetBool("IsHidden", false);
        exitAnm.SetBool("IsHidden", false);
        levelAnm.SetBool("IsHidden", false);


    }

    public void openLevel()
    {
        startAnm.SetBool("IsHidden", true);
        exitAnm.SetBool("IsHidden", true);
        levelAnm.SetBool("IsHidden", true);
        LevelPanelAnm.SetBool("IsHidden", false);
        backAnm.SetBool("IsHidden", false);
    }


}
