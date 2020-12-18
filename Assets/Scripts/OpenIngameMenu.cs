using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenIngameMenu : MonoBehaviour
{
    public Canvas canvas;
    public bool isOpened = false;
    public void ShowHideIGM()
    {
        isOpened = !isOpened;
        canvas.enabled = isOpened;
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ShowHideIGM();
            Debug.Log("Getting");
        }
    }
}
