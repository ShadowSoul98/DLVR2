using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTemp : MonoBehaviour
{

    private int _actualEggs = 0;
    private int _actualKeys = 0;

    public void addEggs(int pickedegg)
    {
        _actualEggs += pickedegg;
        Debug.Log("Total Eggs: "+_actualEggs);
    }

    public void addKey(int pickedKey)
    {
        _actualKeys += pickedKey;
        Debug.Log("Total Keys: " + _actualKeys);
    }

    private void OnTriggerEnter(Collider Other)
    {
        Interaccion interactable = Other.GetComponent<Interaccion>();
        InteraccionKey takeKey = Other.GetComponent<InteraccionKey>();
        if(interactable != null)
        {
            interactable.Interact(this);
        }else if(takeKey != null)
        {
            takeKey.InterKey(this);
        }
    }

}
