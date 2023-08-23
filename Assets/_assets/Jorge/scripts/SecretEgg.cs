using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SecretEgg : MonoBehaviour, Interaccion
{
    private int amount;
    public AudioSource audioSource;

    

    public void Interact(PlayerTemp player)
    {
        player.addEggs(amount);
        audioSource.Play();
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(this.gameObject, audioSource.clip.length);
    }
}