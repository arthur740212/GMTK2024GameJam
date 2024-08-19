using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public RectTransform playerHealth;
    public RectTransform playerMaxHealth;
    public RectTransform playerMana;
    public RectTransform playerMaxMana;

    public RectTransform bossHealth;
    public RectTransform bossMaxHealth;

    public BossStats bossStats;
    public PlayerStats playerStats;

    public Text playerHealthText;
    public Text playerManaText;
    public Text bossHealthText;

    private void Update()
    {
        playerHealth.sizeDelta = new Vector2(1000.0f * playerStats.Health / playerStats.MaxHealth, 50.0f);
        playerMana.sizeDelta = new Vector2(1000.0f * playerStats.Mana / playerStats.MaxMana, 50.0f);
        bossHealth.sizeDelta = new Vector2(1000.0f * bossStats.BossHealth / bossStats.BossMaxHealth, 50.0f);

        playerHealthText.text = $"{playerStats.Health} / {playerStats.MaxHealth}";
        playerManaText.text = $"{playerStats.Mana} / {playerStats.MaxMana}";
        bossHealthText.text = $"{bossStats.BossHealth} / {bossStats.BossMaxHealth}";
    }
}
