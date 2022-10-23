using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    PlayerCollected PCollected;
    PlayerMovement PMovement;
    StairBuilder SBuilder;
    void Start()
    {
        PCollected = GetComponent<PlayerCollected>();
        PMovement = GetComponent<PlayerMovement>();
        SBuilder = GetComponent<StairBuilder>();
    }

    void Update()
    {
        if (PMovement.isLose) return;

        if (Input.GetMouseButtonDown(0))
            PMovement.isRun = true;

        if (!PMovement.isRun | PMovement.isWin) return;

        if(Input.GetMouseButton(0) & PCollected.stairs.Count > 0)
        {
            SBuilder.Build();
            PMovement.UpMove();
        }
        else
            PMovement.ForwardMove();
    }
}
