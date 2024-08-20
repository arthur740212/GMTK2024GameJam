using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("drop to deathzone");
            GameObject player = other.gameObject;
            PlayerStats playerStat = null;

            if (player != null)
            {
                playerStat = player.GetComponent<PlayerStats>();
            }

            if (playerStat != null)
            {
                playerStat.shieldOn = false;
                playerStat.LoseHealth(int.MaxValue);
            }
        }
    }
}
