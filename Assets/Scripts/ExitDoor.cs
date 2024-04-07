using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private bool    playerInRange;
    public  Inventory inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange == true && inventory.numberKeys > 1)
        {
            ; // sair do jogo
        }
    }

    private void    OnTriggerEnter2D(Collider2D other)
    {
        playerInRange = true;
    }

    private void    OnTriggerExit2D(Collider2D other)
    {
        playerInRange = false;
    }
}
