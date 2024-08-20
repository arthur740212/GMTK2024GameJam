using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class BossStats : MonoBehaviour
{
    [SerializeField]
    public int BossHealth = 50;
    public int BossMaxHealth = 10000000;

    [SerializeField]
    public int BossPower = 1;

    [SerializeField]
    public float BossLevelupCD = 90.0f;

    public float SecondsToBossLevelup = 60.0f; 

    public GameObject BossAttackPrefab;

    public HitParticle BossHitParticle;

    public AudioSource hitSFX;
    private void Awake()
    {
        if (BossHealth > BossMaxHealth)
        {
            BossHealth = BossMaxHealth;
        }
    }

    public Image winImage;
    public Color finalWinImageColor;
    public void DealDamage(int damage)
    {
        BossHealth -= damage;
        if (BossHealth <= 0)
        {
            ShowWinImage();
        }
    }

    public async void ShowWinImage()
    {
        float time = 0.0f;
        while (time < 1.0f)
        {
            time += Time.deltaTime;
            winImage.color = Color.Lerp(winImage.color, finalWinImageColor, time);
            await Task.Delay(10);
        }
        SceneManager.LoadScene("EndScene");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireball"))
        {
            other.gameObject.SetActive(false);
            BossHitParticle.transform.position = other.gameObject.transform.position;
            BossHitParticle.PlayAllParticleSystems();
            DealDamage(other.GetComponent<Fireball>().damage);
            hitSFX.Play();
        }
    }
    private void Update()
    {
        SecondsToBossLevelup -= Time.deltaTime;
        if (SecondsToBossLevelup < 0.0f) 
        {
            BossPower *= 2;
            SecondsToBossLevelup += BossLevelupCD;
        }
    }
}
