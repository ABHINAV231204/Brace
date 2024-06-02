using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPaused = false;
  
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("paused");
            if(!isPaused)
            Pause();
            else
            Resume();
        }
    }
    void Pause(){
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

    }
     public void Resume(){
        isPaused = false;
        Time.timeScale = 1f;

        pauseMenu.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
     public void Menu()
    {
              SceneManager.LoadScene("main-menu");

    }
}
