using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenu;

    public void WinScreen(GameObject win)
    {
        win = winMenu;
        Time.timeScale = 0f;
        //winMenu.SetActive(true);
        win.SetActive(true);
    }
}
