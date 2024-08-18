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
    public int MaxHealth = 100;
    public int Armor = 1;
    public int MaxMana = 100;

    public float Projectiles;
    public float HealthRegen;
    public float ShieldRegen;
    public float ManaRegen;

    public List<int> Fibo = new List<int>();

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
                break;
            case CapType.Yellow:
                Yellow_level++;
                break;
            case CapType.Blue:
                Blue_level++;
                break;
        }
    }

}
