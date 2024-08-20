using UnityEngine;

public class BossStats : MonoBehaviour
{
    [SerializeField]
    public int BossHealth = 50;
    public int BossMaxHealth = 10000000;

    [SerializeField]
    private int BossPower = 1;

    [SerializeField]
    private float BossLevelupCD = 60.0f;

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
    public void DealDamage(int damage) 
    {
        BossHealth -= damage;
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
