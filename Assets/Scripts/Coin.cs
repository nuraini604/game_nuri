using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public enum CoinType
    {
        Red,    // +20 points
        Yellow, // +30 points, turns on all lights
        Green,  // +100 points
        Blue,   // +10 health
        Black   // -20 health, turns off all lights
    }

    [Header("Coin Properties")]
    public CoinType coinType;
    public float rotationSpeed = 50f;
    
    // References
    private Light[] allLights;

    void Start()
    {
        // Find all lights in the scene
        allLights = FindObjectsOfType<Light>();
    }

    void Update()
    {
        // Rotate the coin
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get player stats component
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            
            if (playerStats != null)
            {
                // Apply effects based on coin type
                switch (coinType)
                {
                    case CoinType.Red:
                        playerStats.AddPoints(20);
                        break;
                    
                    case CoinType.Yellow:
                        playerStats.AddPoints(30);
                        TurnOnAllLights();
                        break;
                    
                    case CoinType.Green:
                        playerStats.AddPoints(100);
                        break;
                    
                    case CoinType.Blue:
                        playerStats.AdjustHealth(10);
                        break;
                    
                    case CoinType.Black:
                        playerStats.AdjustHealth(-20);
                        TurnOffAllLights();
                        break;
                }

                // Destroy the coin after collection
                Destroy(gameObject);
            }
        }
    }

    // Method to turn on all lights in the scene
    private void TurnOnAllLights()
    {
        foreach (Light light in allLights)
        {
            light.enabled = true;
        }
    }

    // Method to turn off all lights in the scene
    private void TurnOffAllLights()
    {
        foreach (Light light in allLights)
        {
            light.enabled = false;
        }
    }
}
