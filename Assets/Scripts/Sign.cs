using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    private bool    playerInRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && playerInRange == true)
        {
            ;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            playerInRange = false;
    }
}
