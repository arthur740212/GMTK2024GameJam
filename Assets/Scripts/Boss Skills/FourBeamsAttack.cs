using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourBeamsAttack : MonoBehaviour
{
    public int damage = 100;
    public float duration = 0.5f;
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
                playerStat.LoseHealth(damage);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position += Vector3.forward*Time.deltaTime*10.0f;
        Destroy(gameObject, duration);
    }
}
