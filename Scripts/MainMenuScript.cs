using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour {

    public string GameScene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayGame()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
