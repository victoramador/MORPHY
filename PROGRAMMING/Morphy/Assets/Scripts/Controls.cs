using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour {

    public void Controles()
    {
        SceneManager.LoadScene("Controles");
    }
    public void Title()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
