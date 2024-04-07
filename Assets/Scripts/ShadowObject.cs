using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowObject : MonoBehaviour
{
    public RealityShift realityShift;
    private Material ogMaterial;
    private Material invMaterial;
    private int layer1Index; // Index of the first layer
    private int layer2Index;
    private int layer3Index;
    private int layer4Index;
    private int layer5Index; // Index of the second layer

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        ogMaterial = renderer.material;
        invMaterial = new Material(ogMaterial);
        layer1Index = LayerMask.NameToLayer("Player");
        layer2Index = LayerMask.NameToLayer("Dark");
        layer3Index = LayerMask.NameToLayer("Light");
        layer4Index = LayerMask.NameToLayer("DPlatform");
        layer5Index = LayerMask.NameToLayer("WPlatform");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            InvertMatter();
            ApplyMatter();
            ShiftMatter();
        }
    }

    void    InvertMatter()
    {
        Color ogColor = ogMaterial.color;
        Color invColor = new Color(1f - ogColor.r, 1f - ogColor.g, 1f - ogColor.b, 1f - ogColor.a);
        invMaterial.color = invColor;
    }

    void    ApplyMatter()
    {
        bool isInverted = realityShift.GetRealityShift();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = isInverted ? invMaterial : ogMaterial;
    }

    void    ShiftMatter()
    {
        if (realityShift != null)
        {
            bool isInverted = realityShift.GetRealityShift(); // Assuming GetRealityShift() returns a boolean
            if (isInverted)
            {
                if (GetComponent<Rigidbody2D>())
                    gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                if (GetComponent<BoxCollider2D>())
                    GetComponent<BoxCollider2D>().enabled = false;
            }
            else if (!isInverted)
            {
                if (GetComponent<Rigidbody2D>())
                    gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                if (GetComponent<BoxCollider2D>())
                    GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
