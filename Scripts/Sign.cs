using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    private bool    playerInRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange == true)
        {
            Debug.Log("Player trying to read the sign");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            playerInRange = true;
            Debug.Log("Player in sign range");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            playerInRange = false;
            Debug.Log("Player exited sign range");
    }
}
