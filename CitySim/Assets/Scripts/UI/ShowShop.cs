using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShop : MonoBehaviour
{
    public GameObject shopPanel;
    public void openShop()
    {
        shopPanel.SetActive(true);
    }

    public void closeShop()
    {
        shopPanel.SetActive(false);
    }
}
