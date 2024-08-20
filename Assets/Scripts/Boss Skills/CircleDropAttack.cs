using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDropAttack : MonoBehaviour
{
    public int damage = 100;
    public float duration = 0.5f;
    [SerializeField]
    private BossStats bossStats;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("do damage of circle drop");
        if (other.CompareTag("Player"))
        {
            Debug.Log("circle drop hit player");
            GameObject player = other.gameObject;
            PlayerStats playerStat = null;

            if (player != null)
            {
                playerStat = player.GetComponent<PlayerStats>();
            }

            if (playerStat != null)
            {
                playerStat.LoseHealth(damage * bossStats.BossPower);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, duration);
    }
}
