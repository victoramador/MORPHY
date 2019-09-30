using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatewheel : MonoBehaviour {

    private Rigidbody2D r2d;
    public float speed = 100f;
    private float rotation;

	void Start () {
        r2d = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
        rotation = transform.rotation.z;
        if (rotation>0 && rotation <180) { 
            r2d.MoveRotation(r2d.rotation + speed );
           
        }
        if (rotation <= 0 && rotation >-180)
        {
            r2d.MoveRotation(r2d.rotation - speed );
         
        }

    }
}
