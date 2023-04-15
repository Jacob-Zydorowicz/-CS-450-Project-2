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
    [SerializeField] int startingAmount = 500;
    static int currentAmount = 0;
    static Subject subject;

    // Start is called before the first frame update
    void Start()
    {
        subject = GameObject.FindObjectOfType<Subject>();
        currentAmount = startingAmount;
        subject.UpdateIncome(startingAmount);
    }

    public static bool Buy(int amount)
    {
        if(amount<=currentAmount)
        {
            currentAmount -= amount;
            subject.UpdateIncome(currentAmount);
            return true;
        }
        else
            return false;
    }

    public static void AddMoney(int amount)
    {
        currentAmount += amount;
        subject.UpdateIncome(currentAmount);
    }

}
