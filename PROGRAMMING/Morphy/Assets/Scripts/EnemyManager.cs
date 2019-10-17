using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int hits=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hits == 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void LoseLife()
    {
        hits--;
    }
}
