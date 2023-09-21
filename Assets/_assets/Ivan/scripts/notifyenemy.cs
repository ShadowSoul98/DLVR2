using UnityEngine;
public class notifyenemy : MonoBehaviour
{
    public stalkerController notity;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            notity.asignPlayer(other.transform);
        }
    }
}
