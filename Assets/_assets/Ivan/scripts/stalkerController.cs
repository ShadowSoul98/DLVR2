using UnityEngine;
using UnityEngine.AI;
public class stalkerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform objetive;
    public Transform[] nodes;
    public float offSet = 2;
    public Transform player;
    public bool lookPlayer = false;
    private int actualPosition = 0;
    private float countdown;

    void Start()
    {
        if (agent == null)
        {
            agent = this.gameObject.GetComponent<NavMeshAgent>();
        }
        objetive = nodes[0];
    }

    void Update()
    {
        agent.SetDestination(objetive.position);
            Debug.Log(objetive.position);
        if (!lookPlayer)
        {
            Vector3 distance;
            distance = objetive.position - transform.position;
            if (distance.magnitude <= offSet)
            {
                actualPosition++;
                if (actualPosition >= nodes.Length)
                {
                    actualPosition = 0;
                }
                objetive = nodes[actualPosition];
            }
        }
        else{
            objetive = player;
            countdown -= Time.deltaTime;
            if(countdown <= 0f){
                lookPlayer = false;
                objetive = nodes[actualPosition];
            }
        }
    }
    public void asignPlayer(Transform nPlayer)
    {
        player = nPlayer;
        lookPlayer = true;
        countdown = 5f;
    }
}
