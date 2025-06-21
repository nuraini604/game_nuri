using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    // Player attributes
    [Header("Player Stats")]
    public int maxHealth = 100;
    public int currentHealth;
    public int points;

    // UI elements
    [Header("UI References")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI pointsText;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize health and points
        currentHealth = maxHealth;
        points = 0;
        UpdateUI();
    }

    // Method to update health and points UI
    public void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "Health: " + currentHealth;

        if (pointsText != null)
            pointsText.text = "Points: " + points;
    }

    // Method to add or subtract health
    public void AdjustHealth(int amount)
    {
        currentHealth += amount;
        
        // Clamp health between 0 and maxHealth
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        UpdateUI();

        // Check if player is dead
        if (currentHealth <= 0)
        {
            Debug.Log("Player Died!");
            // Implement death behavior here if needed
        }
    }

    // Method to add points
    public void AddPoints(int amount)
    {
        points += amount;
        UpdateUI();
    }
}
