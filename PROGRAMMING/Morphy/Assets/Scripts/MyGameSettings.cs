using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameSettings : MonoBehaviour {

	private static MyGameSettings instance;
    public float minfinal;
    public float segfinal;
	public int color;

	void Awake (){
		if (instance == null) {
			instance = this;
            color = 0;
            DontDestroyOnLoad (this);
            
		}
	}
	public static MyGameSettings getInstance(){
		return instance;
	}
}
