using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision player)
    {
        if (!player.gameObject.CompareTag("Player")) return;

        PlayerMovement PMove = player.gameObject.GetComponent<PlayerMovement>();

        if (PMove.isWin) return;

        Vector3 winPos;
        if (player.transform.position.x > transform.position.x + 1.5f)
        {
            winPos = new Vector3(3, -1.5f, 0);
            Debug.Log(transform.position);
        }
        else
            winPos = new Vector3(0, 1.5f, 0);

        PMove.Win(transform.position + winPos);

    }
}

