using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CO2Manager : MonoBehaviour
{
    [SerializeField] float maxAmount;
    static float max;
    static float currentAmount;
    static Subject subject;
    //public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        currentAmount = 0;
        max = maxAmount;
        subject = FindObjectOfType<Subject>();
        subject.UpdateCO2(currentAmount);
        //gameOver = false;
    }

    static public void UpdateCO2(float value)
    {
        currentAmount += value;
        Debug.Log(currentAmount);
        if (currentAmount >= max)
        {
            subject.UpdateCO2(max);
            GameOver();

            //gameOver = true; 
        }
        else if (currentAmount < 0)
        {
            currentAmount = 0;
            subject.UpdateCO2(0);
        }
        else
            subject.UpdateCO2(currentAmount);

        
    }

    static private void GameOver()
    {
        GameObject.FindObjectOfType<ExtraMenusController>().Lose();
        //Debug.Log("Game Over");
        return;
    }
}
