using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShop : MonoBehaviour
{
    public GameObject shopPanel;
    private bool opened = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(opened)
            {
                shopPanel.SetActive(false);
                opened = false;
            }
            else
            {
                shopPanel.SetActive(true);
                opened = true;
            }
        }
    }
}
