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
    bool moved = false;

    // Update is called once per frame
    void Update()
    {

        Agent.speed = Speed;
        Agent.SetDestination(Objetive.position);
    }
    public void Moved(){
        Debug.Log("enemigo detectado");
        Speed = 20f;
    }
    public void Stalkered(){
        enemy.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisión involucra al objeto que queremos
        if (other.CompareTag("Finish"))
        {
            // Realizar acciones específicas cuando colisiona con el objeto deseado
            Debug.Log("¡Colisión con el objeto deseado!");
            // Aquí puedes realizar cualquier acción adicional que desees.
        }
    }
}
