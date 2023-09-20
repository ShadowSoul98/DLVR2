using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class stalkerController : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform objetive;
    public Transform[] nodes;
    public float offset = 1;
    private int positionActual = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(Agent == null){
            Agent = this.gameObject.GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Agent.SetDestination(objetive.position);
        Vector3 distance;
        distance = objetive.position-transform.position;
        if(distance.magnitude<=offset){
            positionActual++;
            Debug.Log(positionActual);
            if(positionActual > nodes.Length-1){
                positionActual = 0;
            }
            objetive = nodes[positionActual];
        }
    }
}
