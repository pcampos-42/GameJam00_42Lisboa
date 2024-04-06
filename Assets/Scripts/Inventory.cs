using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Collectible"))
            Collect(other.GetComponent<Collectible>());
    }

    private void Collect(Collectible collectible)
    {
        if(collectible.Collect())
            if(collectible is CoinCollectible)
                Debug.Log("Coin Collected");
    }
}