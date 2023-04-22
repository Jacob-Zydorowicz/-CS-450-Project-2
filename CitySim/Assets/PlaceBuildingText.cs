/*
 * (Jacob Welch)
 * (PlaceBuildingText)
 * (CitySim)
 * (Description: )
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaceBuildingText : MonoBehaviour
{
    #region Fields
    private TextMeshProUGUI text;
    private static PlaceBuildingText Instance;
    #endregion

    #region Functions
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        Instance = this;
    }

    public static void SetText(string buildingName, int buildingCost)
    {
        if (Instance == null || Instance.text == null) return;

        Instance.text.text = "Left Click to Place: " + buildingName + " for $" + buildingCost;
    }
    #endregion
}
