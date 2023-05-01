/*
 * (Jacob Welch)
 * (ShopMenuHandler)
 * (CitySim)
 * (Description: )
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuHandler : MonoBehaviour
{
    #region Fields
    [Tooltip("All of the panels that can be displayed in the shop")]
    [SerializeField] private GameObject[] shopPanels;
    #endregion

    #region Functions
    public void SetPanelActive(GameObject panelToSetActive)
    {
        foreach (GameObject panel in shopPanels)
        {
            panel.SetActive(panel == panelToSetActive);
        }
    }
    #endregion
}
