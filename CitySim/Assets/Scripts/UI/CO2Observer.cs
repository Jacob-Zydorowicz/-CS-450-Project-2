using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CO2Observer : Observer
{
    [SerializeField] float maxCO2;
    float currentCO2 = 0;
    public AudioSource halfFullMusic;
    [SerializeField] Image fillBar;
    [SerializeField] Gradient gd;

    private NPCSpawner npcSpawner;

    private void Awake()
    {
        npcSpawner = FindObjectOfType<NPCSpawner>();
        fillBar.fillAmount = 0;
    }

    public override void UpdateVal(int money, float CO2, int turn)
    {
        //Debug.Log(CO2);
        currentCO2 = CO2;
        float temp = Mathf.Clamp(CO2 / maxCO2, 0, 1);
        Debug.Log(temp);
        fillBar.fillAmount = temp;
        fillBar.color = gd.Evaluate(temp);


        if(CO2 >= 50.0f && halfFullMusic.isPlaying == false)
        {
            halfFullMusic.Play();
        }

        if (CO2 >= 50)
        {
            npcSpawner.UpdateNPCNum(Mathf.FloorToInt(-1));
        }
    }
}
