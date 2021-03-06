﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour {

    public Text segText;
	private float seg;
    public Text minText;
    private float min;
    private float mseg;
    public bool firstTime = false;
    public Text livesText;
	public int lives;
    public int hits;
    public Image gelatina;
    public bool vacio = true;
	public GameObject pausaMenu;
	public bool pause=true;
    private static MyGameManager instance;
    public AudioSource music;
   
	void Awake (){
		if (instance == null) {
			instance = this;
		}
        
	}
	public static MyGameManager getInstance(){
		return instance;
	}
	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        gelatina.color = Color.green;
        lives = 3;
        hits = 3;
		livesText.text="x "+lives.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        Addtime();
        if (hits == 3)
        {
            gelatina.color = Color.green;
        }
    }
	public void Loselife (){

        if (vacio == false)
        {
            lives--;
            hits = 3;
            vacio = true;
        }
        else
        {
            if (hits > 1)
            {
                hits--;
                if (hits == 2)
                {
                    gelatina.color = Color.yellow;
                }
                if (hits == 1)
                {
                    gelatina.color = Color.red;
                }
            }
            else if (hits <= 1)
            {
                lives--;
                hits = 3;
            }
        }
        livesText.text = "x " + lives.ToString();
        if (lives < 1)
        {
            SceneManager.LoadScene("GameOver");
            Cursor.visible = true;
        }
    }
    public void Winlife()
    {
        if (hits < 3)
        {
            hits++;
            if (hits == 3)
            {
                gelatina.color = Color.green;
            }
            if (hits == 2)
            {
                gelatina.color = Color.yellow;
            }
            if (hits == 1)
            {
                gelatina.color = Color.red;
            }
        }
          
    }
	public void Addtime(){
        mseg ++ ;
        if (mseg >= 60)
        {
            seg++;
            mseg = 0;
        }
        segText.text= seg.ToString();
        if (seg >= 60)
        {
            min++;
            seg = 0;
        }
        minText.text = min.ToString();
        MyGameSettings.getInstance().minfinal=min;
        MyGameSettings.getInstance().segfinal=seg;

    }
	public void Pausa(){
		if (!pause) {
            pause = true;
            firstTime = true;
            pausaMenu.SetActive (false);
            Cursor.visible = false;
            //music.mute = false;
        } else if (pause) {
            pause = false;
            if (firstTime)
            {
                pausaMenu.SetActive(true);
                firstTime = false;
            }
            pausaMenu.SetActive (true);
            Cursor.visible = true;
            //music.mute = true;
        }
	}
	public void GoTomenu(){
		SceneManager.LoadScene("MainMenu");
		Time.timeScale = 1;
	}
	public void Exit(){
		Application.Quit();
	}
}
