using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonThroughKeySelection : MonoBehaviour
{
    public string key;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            EventSystem.current.SetSelectedGameObject(
                     this.gameObject);
        }
    }
}
