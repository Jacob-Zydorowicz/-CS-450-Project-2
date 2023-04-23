using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenu : MonoBehaviour
{
    public GameObject loseMenu;

    public void LoseScreen(GameObject lose)
    {
        lose = loseMenu;
        Time.timeScale = 0f;
        //loseMenu.SetActive(true);
        lose.SetActive(true);
    }
}
