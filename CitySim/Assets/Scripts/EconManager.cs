using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconManager : MonoBehaviour
{
    [SerializeField] int startingAmount = 100;
    int currentAmount;
    //Subject subject

    // Start is called before the first frame update
    void Start()
    {
        //subject = GameObject.FindObjectOfType<Subject>();
        currentAmount = startingAmount;
        //subject.UpdateVal()
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
