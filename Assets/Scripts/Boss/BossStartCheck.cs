using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartCheck : MonoBehaviour
{

    public string tagToCheck = "Player";

    public GameObject bossCamera;
    public GameObject boss;

    private void Awake()
    {
        bossCamera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToCheck)
        {
            TurnBossOn();
            TurnCameraOn();
        }
    }

    private void TurnCameraOn()
    {
        bossCamera.SetActive(true);
    }

    private void TurnBossOn()
    {
        boss.SetActive(true);
    }
}
