using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    List<Observer> observers;
    int money;
    float CO2;
    int turnNum;
    // Start is called before the first frame update
    void Awake()
    {
        observers = new List<Observer>();
    }

    public void Register(Observer ob)
    {
        observers.Add(ob);
        UpdateAll();
    }

    public void Unregister(Observer ob)
    {
        observers.Remove(ob);
        UpdateAll();
    }

    private void UpdateAll()
    {
        foreach(Observer ob in observers)
        {
            ob.UpdateVal(money, CO2, turnNum);
        }
    }

    public void UpdateIncome(int value)
    {
        money = value;
        UpdateAll();
    }

    public void UpdateCO2(float value)
    {
        CO2 = value;
        UpdateAll();
    }

    public void UpdateTurn(int value)
    {
        CO2 = value;
        UpdateAll();
    }
}
