using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool    doubleJump;
    public int     numberKeys;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Collectible"))
            Collect(other.GetComponent<Collectible>());
    }

    private void Collect(Collectible collectible)
    {
        if(collectible.Collect())
        {
            if(collectible is DoubleJumpCollectible)
            {
                Debug.Log("Double Jump Collected");
                doubleJump = true;
            }
            if(collectible is KeyCollectible)
            {
                Debug.Log("Key Collected");
                numberKeys++;
            }
        }
    }
}