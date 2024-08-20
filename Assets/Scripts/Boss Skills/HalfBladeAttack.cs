using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfBladeAttack : MonoBehaviour
{
    public int damage = 100;
    public float duration = 0.2f;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("do damage of halfblade");
        if (other.CompareTag("Player"))
        {
            Debug.Log("halfblade hit player");
            GameObject player = other.gameObject;
            PlayerStats playerStat = null;

            if (player != null)
            {
                playerStat = player.GetComponent<PlayerStats>();
            }
            
            if (playerStat != null)
            {
                playerStat.LoseHealth(damage);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, duration);

    }
}
