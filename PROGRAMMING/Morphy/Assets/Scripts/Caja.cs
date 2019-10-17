using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour {

    public ControladorPersonaje player;
    private Collider2D col;
    public SpriteRenderer caja;
    private void Awake()
    {
        col= GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && player.isattacking==false)
        {
            Destroy();
        }
    }
    private void Destroy()
    {
        col.enabled = false;
        Destroy(caja.gameObject);
    }
    /*private void Reset()
    {
        col.enabled = true;
        caja.gameObject.SetActive(true);
    }*/
}
