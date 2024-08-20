using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public float AttackRegen = 2.0f;
    public float HealthRegen = 1.0f;
    public float ShieldRegen = 2.0f;
    public float ManaRegen = 3.0f;

    public float AttackCD = 1.0f;
    private float HealthCD = 1.0f;
    private float ShieldCD = 2.0f;
    private float ManaCD = 3.0f;

    public int Health = 100;
    public int Mana = 100;
    public Shield Shield;

    private int AddHealthAmount = 10;
    private int AddManaAmount = 10;

    public ParticleSystem AddHealthParticle;
    public ParticleSystem AddManaParticle;
    public ParticleSystem AddShieldParticle;

    public List<int> Fibo = new List<int>();

    private void Update()
    {
        AttackCD -= Time.deltaTime;
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
        if (!AddHealthParticle.isPlaying) 
        {
            AddHealthParticle.Play();
        }
        Health += AddHealthAmount;
        Health = Mathf.Min(Health, MaxHealth);
    }

    private void ApplyShield()
    {
        if (!AddShieldParticle.isPlaying)
        {
            AddShieldParticle.Play();
        }
        Debug.Log("New Shilewed");
        Shield.shieldOn = true;
    }
    private void AddMana()
    {
        if (!AddManaParticle.isPlaying)
        {
            AddManaParticle.Play();
        }
        Mana += AddManaAmount;
        Mana = Mathf.Min(Mana, MaxMana);
    }

    public Image deathImage;
    public Color finalDeathImageColor;
    public void LoseHealth(int damage)
    {
        Health -= damage;
        if (Health < 0) 
        {
            ShowDeathImage();
        }
    }
    
    public async void ShowDeathImage()
    {
        float time = 0.0f;
        while (time < 3.0f)
        {
            time += Time.deltaTime;
            deathImage.color = Color.Lerp(deathImage.color, finalDeathImageColor, time);
            await Task.Delay(10);
        }
        SceneManager.LoadScene("EndScene");
    }

    public void LoseMana(int deplete)
    {
        Mana -= deplete;
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
                if (Green_level < 40)
                {
                    MaxHealth += Fibo[Green_level];
                }
                else 
                {
                    MaxHealth = int.MaxValue;
                }
                break;
            case CapType.Yellow:
                Armor += Yellow_level * 2;
                break;
            case CapType.Blue:
                if (Blue_level < 40)
                {
                    MaxMana += Fibo[Blue_level];

                }
                else
                {
                    MaxMana = int.MaxValue;
                }
                break;
        }
    }

    public void LevelUp(CapType type)
    {
        switch (type)
        {
            case CapType.Red:
                Red_level++;
                AttackRegen = Red_Stat.Evaluate(Red_level);
                break;
            case CapType.Green:
                Green_level++;
                HealthRegen = Green_Stat.Evaluate(Green_level);
                break;
            case CapType.Yellow:
                Yellow_level++;
                ShieldRegen = Yellow_Stat.Evaluate(Yellow_level);
                break;
            case CapType.Blue:
                Blue_level++;
                ManaRegen = Blue_Stat.Evaluate(Blue_level);
                break;
        }
    }

}
