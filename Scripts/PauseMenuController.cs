using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {

    public string MainMenuScene;
    public GameObject PauseScreen;
    public bool isPaused;
    private bool Pressed;
    
    // Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
                PauseScreen.SetActive(true);
                Time.timeScale = 0f;
            }
        }

		
	}

    public void ResumeGame()
    {
        isPaused = false;
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturntoMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainMenuScene);
    }
}
