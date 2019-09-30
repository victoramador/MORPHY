using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
        //Time.timeScale = 0;
    }
    public void EndGame()
    {

        Application.Quit();
    }
    public void Controles()
    {
        SceneManager.LoadScene("Controls");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Title(){
        SceneManager.LoadScene("MainMenu");
    }
}
