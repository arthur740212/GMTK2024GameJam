using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Slider playerHealthSlider;
    public Slider playerManaSlider;

    public RectTransform bossHealth;
    public RectTransform bossMaxHealth;

    public BossStats bossStats;
    public PlayerStats playerStats;

    public Text playerHealthText;
    public Text playerManaText;
    public Text bossHealthText;

    public float currentHealth = 1;
    public float currentMana = 1;
    public float currentBossHealth = 1;

    private void Update()
    {
        currentHealth = 0.9f * currentHealth + 0.1f * playerStats.Health;
        currentMana = 0.9f * currentMana + 0.1f * playerStats.Mana;
        currentBossHealth = 0.9f * currentBossHealth + 0.1f * bossStats.BossHealth;

        playerHealthSlider.value = currentHealth / (float)playerStats.MaxHealth;
        playerManaSlider.value = currentMana/ (float)playerStats.MaxMana;

        playerHealthText.text = $"{playerStats.Health} / {playerStats.MaxHealth}";
        playerManaText.text = $"{playerStats.Mana} / {playerStats.MaxMana}";
        bossHealthText.text = $"{bossStats.BossHealth} / {bossStats.BossMaxHealth}";
    }
}
