using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light[] sceneLights;
    public bool defaultState = true;

    void Start()
    {
        // If no lights are assigned, find all lights in the scene
        if (sceneLights == null || sceneLights.Length == 0)
        {
            sceneLights = FindObjectsOfType<Light>();
        }

        // Set default state
        SetLightsState(defaultState);
    }

    // Method to set all lights on or off
    public void SetLightsState(bool state)
    {
        foreach (Light light in sceneLights)
        {
            if (light != null)
                light.enabled = state;
        }
    }
}
