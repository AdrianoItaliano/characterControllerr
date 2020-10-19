using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update


    public float timeToDestroy = 2f, iterator;
    void Start()
    {
        iterator = 50 * timeToDestroy;
    }

    void FixedUpdate()
    {
        iterator--;
        if(iterator==0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
