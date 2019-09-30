using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour {


    public GameObject objecttofollow;
    public float separacion = 6f;


    // Update is called once per frame
    void FixedUpdate () {
        transform.position = new Vector3(objecttofollow.transform.position.x + separacion, transform.position.y, transform.position.z);
    }
}
