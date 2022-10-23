using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishSpawner : MonoBehaviour
{
    PlayerMovement PMove;
    StairBuilder SBuilder;
    [SerializeField] GameObject TextMesh;
    [SerializeField] Transform player;
    Transform lastCube;
    Vector3 spawnPos;
    int randCount;
    bool isFinishing = false;
    void Start()
    {
        PMove = player.gameObject.GetComponent<PlayerMovement>();
        SBuilder = player.gameObject.GetComponent<StairBuilder>();

        randCount = Random.Range(15,33);
        spawnPos = transform.position;
        for(int i = 1; i < randCount; i++)
        {
            spawnPos += new Vector3(-3, 3, 0);
            SpawnCube(spawnPos, i);
            SpawnText(spawnPos + new Vector3(1.51f, 0, 0), new Vector3(0, -90, 0), i);
            SpawnText(spawnPos + new Vector3(0,1.51f,0), new Vector3(90, 0, 90), i);
        }
    }

    private void Update()
    {
        if (player.position.x < transform.position.x && !isFinishing)
        {
            PMove.speed *= 2.2f;
            SBuilder.timeBetweenSpawn /= 2.2f;
            isFinishing = true;
        }
        else if(player.position.x < lastCube.position.x + 2f && !PMove.isWin)
        {
            PMove.Win(lastCube.position + new Vector3(0,1.5f,0));
        } 
    }

     void SpawnCube(Vector3 position,float index)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = position;
        cube.transform.localScale = new Vector3(3, 3, 3);
        cube.transform.parent = transform;

        cube.AddComponent<FinishTrigger>();
        lastCube = cube.transform;

        cube.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.red, Color.green, index / randCount);
    }

    void SpawnText(Vector3 position, Vector3 rotation, int index)
    {
        var text = Instantiate(TextMesh, position, Quaternion.Euler(rotation));
        text.transform.SetParent(transform,true);
        TextMeshPro tm = text.GetComponent<TextMeshPro>();
        tm.text = "x" + index;
    }
}
