using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityShift : MonoBehaviour
{
    private Material ogMaterial;
    private Material invMaterial;
    private bool isInverted = false;
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        ogMaterial = renderer.material;
        invMaterial = new Material(ogMaterial);
        InvertMater();
        ApplyMater();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isInverted = !isInverted;
            InvertMater();
            ApplyMater();
            ToggleCol();
        }
    }

    void    InvertMater()
    {
        Color ogColor = ogMaterial.color;
        Color invColor = new Color(1f - ogColor.r, 1f - ogColor.g, 1f - ogColor.b
        );
        invMaterial.color = invColor;
    }

    void    ApplyMater()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = isInverted ? invMaterial : ogMaterial;
    }
    void    ToggleCol()
    {
        GameObject[] toggleObj = GameObject.FindGameObjectsWithTag("Coll");
        foreach (GameObject obj in toggleObj)
        {
            Debug.Log("Toggle collision for: " + obj.name);
            if (!wall_floor(obj))
            {
                Collider collider = obj.GetComponent<Collider>();
                if (collider !=  null)
                {
                    collider.enabled = isInverted;
                    Debug.Log("Toggled for: " + collider.enabled);
                }
            }
        }
    }
    bool    wall_floor(GameObject obj)
    {
        return obj.CompareTag("Floor");
    }
}
