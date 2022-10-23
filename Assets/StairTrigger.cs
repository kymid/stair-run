using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StairTrigger : MonoBehaviour
{

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerCollected>().TakeStair(transform);
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
