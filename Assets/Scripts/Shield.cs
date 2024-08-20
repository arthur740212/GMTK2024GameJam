using UnityEngine;

public class Shield : MonoBehaviour
{
    public PlayerStats playerStats;
    public bool shieldOn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossAttack"))
        {
            if (shieldOn)
            {
                shieldOn = false;
                playerStats.AddShieldParticle.Stop();
                playerStats.AddShieldParticle.Clear();
                Debug.Log("ShieldBroke");
            }

            else
            {
                Debug.Log("Lose Health");
                playerStats.LoseHealth(5);
            }
        }
    }
}
