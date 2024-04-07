using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{
     public RealityShift realityShift;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && realityShift.inventory.canInvertColor == true)
        {
            if(realityShift.GetRealityShift() == true)
            {
                Appear();
            }
            else
            {
                Desappear();
            }
        }
    }

    private void Desappear()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;
        GetComponent<SpriteRenderer>().color = tmp;
        if (GetComponent<Rigidbody2D>())
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        if (GetComponent<BoxCollider2D>())
            GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Appear()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        GetComponent<SpriteRenderer>().color = tmp;
        if (GetComponent<Rigidbody2D>())
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        if (GetComponent<BoxCollider2D>())
            GetComponent<BoxCollider2D>().enabled = true;
    }
}
