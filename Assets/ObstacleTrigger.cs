using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    int removedStairs = 15;
    private void OnCollisionEnter(Collision player)
    {
        if (!player.gameObject.CompareTag("Player")) return;

        PlayerCollected PCollected = player.gameObject.GetComponent<PlayerCollected>();
        StairBuilder SBuilder = player.gameObject.GetComponent<StairBuilder>();

        Vector3 jumpDirection;

        if (PCollected.stairs.Count > 0)
        {
            RemoveStairs(PCollected);
            SBuilder.canBuild = false;
            jumpDirection = new Vector3(2, 2, 0);
        }
        else
        {
            jumpDirection = new Vector3(5, 5, 0);
            player.gameObject.GetComponent<PlayerMovement>().Lose();
        }
        player.transform.DOJump(player.transform.position + jumpDirection, 1f, 1, .7f).OnComplete(() =>
        {
            SBuilder.canBuild = true;
        });
    }

    private void RemoveStairs(PlayerCollected PCollected)
    {
        for(int i = 0; i < removedStairs; i++)
        {
            if (PCollected.stairs.Count == 0) return;

            var stair = PCollected.stairs[PCollected.stairs.Count - 1];
            PCollected.stairs.Remove(stair);
            Destroy(stair.gameObject);

        }
    }
}
