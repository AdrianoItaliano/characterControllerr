using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform door;
    public Transform openPosition;
    public Transform closePosition;

    public bool open = false;
    public float speed = 5;
    void Start()
    {
        door.transform.position = closePosition.transform.position; 
    }

    void Update()
    {
        if(open && Vector3.Distance(door.position, openPosition.position)>0f)
        {
            door.position = Vector3.MoveTowards(door.position, openPosition.position, speed * Time.deltaTime);
        }
    }

    public void OpenClose()
    {
        open = !open;
    }
}
