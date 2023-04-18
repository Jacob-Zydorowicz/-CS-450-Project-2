using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCSpawner : ObjectPooler
{
    private Queue<GameObject> activeNPCs = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnNPC()
    {
        GameObject newNPC = SpawnFromPool("NPC", Random.insideUnitCircle * 10f, Quaternion.identity);
        activeNPCs.Enqueue(newNPC);
    }

    public void DespawnNPC()
    {
        if (activeNPCs.Count > 0)
        {
            ReturnObjectToPool("NPC", activeNPCs.Peek());
        }

    }

    public void UpdateNPCNum(int numToSpawn)
    {
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
                SpawnNPC();
            }
            else
            {
                DespawnNPC();
            }
        }
    }
}
