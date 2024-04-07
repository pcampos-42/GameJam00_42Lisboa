using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool    playerInRange;
    public  Inventory inventory;
    public  SpriteRenderer spriteRenderer;
    public  Sprite newSprite;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange == true && inventory.numberKeys > 0)
        {
            inventory.numberKeys--;
            inventory.canInvertColor = true;
            GetComponent<Collider2D>().enabled = false;
            ChangeSprite();
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


    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite; 
    }
}
