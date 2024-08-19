using UnityEngine;

public class BossStats : MonoBehaviour
{
    [SerializeField]
    private int BossHealth = 10000000;

    [SerializeField]
    private int BossPower = 1;

    [SerializeField]
    private float BossLevelupCD = 60.0f;

    public float SecondsToBossLevelup = 60.0f; 

    public GameObject BossAttackPrefab;

    public HitParticle BossHitParticle;

    private void Awake()
    {
        
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
            DealDamage(2);
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
