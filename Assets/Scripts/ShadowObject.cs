using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowObject : MonoBehaviour
{
    public RealityShift realityShift;
    public string layer1name = "Player";
    public string layer2name = "Dark";
    private int layer1Index; // Index of the first layer
    private int layer2Index; // Index of the second layer

    void Start()
    {
        // Get layer indices based on layer names
        layer1Index = LayerMask.NameToLayer("Player");
        layer2Index = LayerMask.NameToLayer("Dark");
    }

    void Update()
    {
        if (realityShift != null)
        {
        // Determine if collisions should be ignored based on isInverted state
        bool isInverted = realityShift.GetRealityShift(); // Assuming GetRealityShift() returns a boolean

        // Use the determined state to toggle layer collision
        Physics2D.IgnoreLayerCollision(layer1Index, layer2Index, isInverted);
        }
    }
}
