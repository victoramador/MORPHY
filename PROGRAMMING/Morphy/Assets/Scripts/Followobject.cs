using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followobject : MonoBehaviour {


    public GameObject objecttofollow;
    // Update is called once per frame
    void FixedUpdate () {
        transform.position = new Vector3(objecttofollow.transform.position.x,transform.position.y, transform.position.z);
    }
}
