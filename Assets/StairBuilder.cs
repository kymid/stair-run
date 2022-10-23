using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBuilder : MonoBehaviour
{
    public bool canBuild = true;
    [SerializeField] Transform enviroment;
    [SerializeField] Transform stairTarget;

    public float timeBetweenSpawn;
    float timeToSpawn;

    PlayerCollected PCollected;
    private void Start()
    {
        PCollected = GetComponent<PlayerCollected>();
    }

    private void FixedUpdate()
    {
        timeToSpawn -= Time.fixedDeltaTime;
    }

    public void Build()
    {
        if (!canBuild) return;

        if(timeToSpawn > 0) return;

        var stair = PCollected.stairs[PCollected.stairs.Count - 1];
        PCollected.stairs.Remove(stair);
        stair.SetParent(enviroment, true);
        stair.transform.position = stairTarget.position;
        stair.transform.localScale = new Vector3(1f, .2f, .4f);

        timeToSpawn = timeBetweenSpawn;
    }
}
