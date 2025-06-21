using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI pointsText;

    [Header("Player Reference")]
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        // If player stats reference is not set, try to find it
        if (playerStats == null)
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }

        // Setup reference from player to UI elements
        if (playerStats != null)
        {
            playerStats.healthText = healthText;
            playerStats.pointsText = pointsText;
            playerStats.UpdateUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Nothing needed here for basic functionality
    }
}
