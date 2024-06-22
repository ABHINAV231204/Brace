using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public ParticleSystem[] snow = new ParticleSystem[2];
    public AudioSource clicks;
    public AudioClip clickSound;
    
    //This had to be done...sort order ain't working;
    public GameObject canvas;

    bool isPaused = false;
  
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("paused");
            if(!isPaused)
            Pause();
            else
            Resume();

            snow[0].emissionRate = 100*Time.unscaledDeltaTime;
            snow[1].emissionRate = 100*Time.unscaledDeltaTime;

        }
    }
    void Pause(){
        isPaused = true;
        Time.timeScale = 0f;
        clicks.PlayOneShot(clickSound);
        pauseMenu.SetActive(true);
        canvas.SetActive(false);

    }
     public void Resume(){
        clicks.PlayOneShot(clickSound);

        isPaused = false;
        Time.timeScale = 1f;

        pauseMenu.SetActive(false);
        canvas.SetActive(true);

    }
    public void Restart()
    {
        clicks.PlayOneShot(clickSound);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
     public void Menu()
    {
              SceneManager.LoadScene("main-menu");

    }
   
}
