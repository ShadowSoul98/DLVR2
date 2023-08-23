using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Keys : MonoBehaviour, InteraccionKey
{
    private int amount;
    public AudioSource audioSource;

    

    public void InterKey(PlayerTemp player)
    {
        player.addKey(amount);
        audioSource.Play();
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(this.gameObject, audioSource.clip.length);
    }
}