using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public Stat Stat_Cooldown;
    public Fireball FireballPrefab;
    public PlayerStats playerStats;

    public float remaining_cooldown = 0.1f;
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
        remaining_cooldown -= Time.deltaTime;
        if (remaining_cooldown < 0.0f) 
        {
            Shoot();
            remaining_cooldown += Stat_Cooldown.Value;
        }
    }
}
