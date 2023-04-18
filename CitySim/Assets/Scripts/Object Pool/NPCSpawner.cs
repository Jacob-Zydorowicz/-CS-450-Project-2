using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : ObjectPooler
{
    int numActiveNPCs = 0;

    // Start is called before the first frame update
    void Start()
    {
        numActiveNPCs = 0;
    }

    public void UpdateNPCNum(int currentCO2)
    {
        int numToSpawn = numActiveNPCs - currentCO2;

        bool positiveNumToSpawn = true;
        if(numToSpawn < 0)
        {
            numToSpawn *= -1;
            positiveNumToSpawn = false;
        }

        for (int i = 0; i < numToSpawn; i++)
        {
            if(positiveNumToSpawn)
            {
                SpawnFromPool("NPC", Random.insideUnitCircle * 10f, Quaternion.identity);
            }
            else
            {
                ReturnObjectToPool("NPC", transform.GetChild(i).gameObject);
            }
        }
    }
}
