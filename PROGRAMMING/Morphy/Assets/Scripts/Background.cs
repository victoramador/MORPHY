using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
	private Material mat;
	public float speed;
	private Vector2 offset;
    public ControladorPersonaje player;
	// Use this for initialization
	void Awake () {
		mat = GetComponent <Renderer> ().material;
		offset = new Vector2 (0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        
        if ((player.GetComponent<Rigidbody2D>().velocity.x < 0))
        {
            speed =0.02f ;
            offset.x += speed * Time.deltaTime;

            
        }else if ((player.GetComponent<Rigidbody2D>().velocity.x >0))
        {
            //speed = player.move;
            offset.x -= speed * Time.deltaTime;
        }
		if (offset.x > 100) {
			offset.x -= 100;
		}
		mat.SetTextureOffset ("_MainTex", offset);
	}
}
