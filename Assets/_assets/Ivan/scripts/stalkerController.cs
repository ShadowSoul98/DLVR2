using UnityEngine;
using UnityEngine.AI;
public class stalkerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform objetive;
    public Transform[] nodes;
    public float offSet = 2;
    private int actualPosition = 0;

    void Start() {
        if(agent == null){
            agent = this.gameObject.GetComponent<NavMeshAgent>();
        }
        objetive = nodes[0];
    }

    void Update() {
        agent.SetDestination(objetive.position);
        Vector3 distance;
        distance = objetive.position - transform.position;
        if(distance.magnitude<=offSet){
            actualPosition++;
            if(actualPosition >= nodes.Length){
                actualPosition = 0;
            }
            objetive = nodes[actualPosition];
        }
    }
    
}
