using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class stalkerActive : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public GameObject enemy;
    public int wall;
    public bool actibe = true;

    public void activeStalkered(){
        if(actibe){        
        enemy.GetComponent<enemyController>().transform.SetPositionAndRotation(start.position,start.rotation);
        enemy.GetComponent<enemyController>().Objetive.SetPositionAndRotation(end.position,end.rotation);
        enemy.SetActive(true);
        actibe = false;
        }
    }
}
