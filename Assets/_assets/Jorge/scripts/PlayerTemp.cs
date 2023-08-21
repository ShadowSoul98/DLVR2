using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTemp : MonoBehaviour
{

    private int _actualEggs = 0;

    public void addEggs(int pickedegg)
    {
        _actualEggs += pickedegg;
        Debug.Log("Total Eggs: "+_actualEggs);
    }


    private void OnTriggerEnter(Collider Other)
    {
        Interaccion interactable = Other.GetComponent<Interaccion>();
        if(interactable != null)
        {
            interactable.Interact(this);
        }
    }

}
