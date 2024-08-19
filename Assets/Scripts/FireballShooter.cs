using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public Fireball FireballPrefab;
    public PlayerStats playerStats;
    public int ManaCost = 2;

    public void Shoot() 
    {
        var obj = Instantiate(FireballPrefab, transform.position, transform.rotation);
        obj.damage = playerStats.Damage;
    }

    private void Start()
    {
    }

    private void Update()
    {

        if (playerStats.AttackCD < 0.0f) 
        {
            if (playerStats.Mana > ManaCost)
            {
                Shoot();
                playerStats.Mana -= ManaCost;
            }
            playerStats.AttackCD += playerStats.AttackRegen;
        }
    }
}
