using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Stat Red_Stat;
    public Stat Green_Stat;
    public Stat Yellow_Stat;
    public Stat Blue_Stat;

    public int Red_level = 1;
    public int Green_level = 1;
    public int Yellow_level = 1;
    public int Blue_level = 1;

    public int Damage = 1;
    public int MaxHealth = 10000;
    public int Armor = 1;
    public int MaxMana = 10000;

    public float Projectiles;
    public float HealthRegen=1.0f;
    public float ShieldRegen=2.0f;
    public float ManaRegen=3.0f;

    private float HealthCD = 1.0f;
    private float ShieldCD = 2.0f;
    private float ManaCD = 3.0f;

    public int Health = 100;
    public int Mana = 100;

    private int AddHealthAmount = 10;
    private int AddManaAmount = 10;

    public List<int> Fibo = new List<int>();

    private void Update()
    {
        HealthCD -= Time.deltaTime;
        ShieldCD -= Time.deltaTime;
        ManaCD -= Time.deltaTime;

        if (HealthCD < 0.0f)
        {
            AddHealth();
            HealthCD += HealthRegen;
        }

        if (ShieldCD < 0.0f) 
        {
            ApplyShield();
            ShieldCD += ShieldRegen;
        }
        if (ManaCD < 0.0f) 
        {
            AddMana();
            ManaCD += ManaRegen; 
        }
    }

    private void AddHealth()
    {
        Debug.Log("Health up");
        Health += AddHealthAmount;
        Health = Mathf.Min(Health, MaxHealth);
    }
    private void ApplyShield()
    {
        Debug.Log("New Shilewed");

    }
    private void AddMana()
    {
        Debug.Log("Mana up");

        Mana += AddManaAmount;
        Mana = Mathf.Min(Mana, MaxMana);
    }

    private void FiboInit()
    {
        Fibo.Add(1);
        Fibo.Add(1);
        for (int i = 2; i < 40; i++)
        {
            Fibo.Add(Fibo[i - 1] + Fibo[i - 2]);
        }
    }

    private void Awake()
    {
        FiboInit();
    }

    public void Pickup(CapType type)
    {
        switch (type)
        {
            case CapType.Red:
                Damage += Red_level;
                break;
            case CapType.Green:
                MaxHealth += Fibo[Green_level];
                break;
            case CapType.Yellow:
                Armor += Yellow_level * 2;
                break;
            case CapType.Blue:
                MaxMana += Fibo[Blue_level];
                break;
        }
    }

    public void LevelUp(CapType type)
    {
        switch (type)
        {
            case CapType.Red:
                Red_level++;
                break;
            case CapType.Green:
                Green_level++;
                HealthRegen = Green_Stat.Value;
                break;
            case CapType.Yellow:
                Yellow_level++;
                ShieldRegen = Yellow_Stat.Value;
                break;
            case CapType.Blue:
                Blue_level++;
                ManaRegen = Blue_Stat.Value;
                break;
        }
    }



}
