using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform finish;
    Image bar;
    float maxDistance;
    void Start()
    {
        bar = GetComponent<Image>();
        maxDistance = finish.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = player.position.x / maxDistance;
    }
}
