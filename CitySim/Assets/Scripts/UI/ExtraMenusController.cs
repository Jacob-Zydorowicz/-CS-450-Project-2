using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExtraMenusController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu, loseMenu, winMenu;
    bool won = false;

    private void Start()
    {
        won = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    private void Pause()
    {
        if(pauseMenu.activeInHierarchy)
        {
            Resume();
        }
        else if (Time.timeScale!= 0f)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }
    public void Lose()
    {
        Time.timeScale = 0f;
        loseMenu.SetActive(true);
    }

    public void Win()
    {
        if (!won)
        {
            won = true;
            Time.timeScale = 0f;
            winMenu.SetActive(true);
        }
    }
}
