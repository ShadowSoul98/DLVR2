using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public Transform Objetive;
    public GameObject enemy;
    public float Speed = 0f;
    public NavMeshAgent Agent;

    // Update is called once per frame
    void Update()
    {
        Agent.speed = Speed;
        Agent.SetDestination(Objetive.position);
        if (!Agent.pathPending && Agent.remainingDistance <= Agent.stoppingDistance){
            unStalkered();
        }
    }
    public void Moved(){
        Speed = 20f;
    }
    public void unStalkered(){
        Agent.speed = 0f;
        enemy.SetActive(false);
    }
}
