using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public bool moving = false;
    public float possibleMoveRadius = 10f;
    public float moveSpeed = 10f;
    
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            
            if(Vector3.Distance(transform.position, destination) < 0.5f)
            {
                moving = false;
            }
        }
        else
        {
            destination = Random.insideUnitCircle * possibleMoveRadius;
            moving = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, possibleMoveRadius);
    }
}
