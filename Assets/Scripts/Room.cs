using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public GameObject virtualCam;
    public Room closeRoom1;
    public Room closeRoom2;

    private void    OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(true);
            closeRoom1.virtualCam.SetActive(false);
            closeRoom2.virtualCam.SetActive(false);
        }
    }
}
