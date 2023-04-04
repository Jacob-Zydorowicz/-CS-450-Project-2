using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer : MonoBehaviour
{
    protected Subject subject;
    // Start is called before the first frame update
    void Start()
    {
        subject = FindObjectOfType<Subject>();
        subject.Register(this);
    }

    // Update is called once per frame
    public abstract void UpdateVal(int money, float CO2, int turn);
}
