using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			
			GameObject personaje = GameObject.Find("Personaje");
			personaje.SetActive(false);
		}
	}
}
