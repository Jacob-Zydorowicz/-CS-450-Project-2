/*
 * Josh Bonovich, Jacob Zydorowicz
 * EconManager.cs
 * City Sim Project
 * Manages and displays economy
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EconManager : MonoBehaviour
{
    [SerializeField] int startingAmount = 100;
    int currentAmount;
    public TextMeshProUGUI moneyText;
    //Subject subject

    // Start is called before the first frame update
    void Start()
    {
        //subject = GameObject.FindObjectOfType<Subject>();
        currentAmount = startingAmount;
        //subject.UpdateVal()
    }

    private void Update()
    {
        moneyText.text = "Balance: $" + string.Format("{0:#.00}", Convert.ToDecimal(currentAmount));
        //testing money gain code
        /*if (Input.GetKey(KeyCode.Space))
        {
            currentAmount += 100;
        }*/
    }

    public bool Buy(int amount)
    {
        if(amount>=currentAmount)
        {
            currentAmount -= amount;
            //subject.UpdateVal();
            return true;
        }
        else
            return false;
    }

    public void addMoney(int amount)
    {
        currentAmount += amount;
        //subject.UpdateVal();
    }
}
