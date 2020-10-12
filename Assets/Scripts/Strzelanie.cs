using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strzelanie : MonoBehaviour
{
    public GameObject pref;
    public float bulletSpeed = 400f;
    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject kula = Instantiate(pref,transform.position,Quaternion.identity);
            Rigidbody rb = kula.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * bulletSpeed * Time.deltaTime);
        }
    }
}
