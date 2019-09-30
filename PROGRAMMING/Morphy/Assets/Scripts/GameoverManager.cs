using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverManager : MonoBehaviour {
    public Text minText;
    public Text segText;
    private void Start()
    {
        Cursor.visible = true;
        AddTime();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
        
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void Title(){
        SceneManager.LoadScene("MainMenu");
    }
    public void AddTime()
    {
        minText.text = MyGameSettings.getInstance().minfinal.ToString();
        segText.text = MyGameSettings.getInstance().segfinal.ToString();
    }
    }
