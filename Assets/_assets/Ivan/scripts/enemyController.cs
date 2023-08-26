using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public Transform Objetive;
    public float Speed;
    public NavMeshAgent Agent;

    // Update is called once per frame
    void Update()
    {
        Agent.speed = Speed;
        Agent.SetDestination(Objetive.position);
    }
}
