using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    public float mouseSpeed = 100f;
    public Transform playerBody;
    public float rotation = 0f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;


        
    }

    void Update()
    {
        float moveX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        rotation -= moveY;
        rotation = Mathf.Clamp(rotation, -90f, 80f);
        transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * moveX);
        


    }
}
