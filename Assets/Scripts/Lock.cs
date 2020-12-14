using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool iCanOpen = false;
    public Door[] doors;
    public KeyColor myColor;
    public bool unlocked = false;
    Animator key;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            iCanOpen = true;
            Debug.Log("You can use the lock!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            iCanOpen = false;
            Debug.Log("You cannot use the lock!");
        }
    }
    void Start()
    {
        key = GetComponent<Animator>();
    }

    public void UseKey()
    {
        foreach(Door door in doors)
        {
            door.OpenClose();
        }
    }

    public bool CheckTheKey()
    {
        if(GameManager.gameManager.redKeys>0 && myColor == KeyColor.Red)
        {
            GameManager.gameManager.redKeys--;
            unlocked = true;
            return true;
        }
        else if(GameManager.gameManager.greenKeys>0 && myColor == KeyColor.Green)
        {
            GameManager.gameManager.greenKeys--;
            unlocked = true;
            return true;
        }
        else if(GameManager.gameManager.goldKeys>0 && myColor==KeyColor.Gold)
        {
            GameManager.gameManager.goldKeys--;
            unlocked = true;
            return true;
        }
        else
        {
            Debug.Log("Nie masz klucza");
            return false;
        }
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&& iCanOpen && !unlocked)
        {
            key.SetBool("useKey", CheckTheKey());
        }

    }
}
