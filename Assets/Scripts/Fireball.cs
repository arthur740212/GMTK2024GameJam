using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Stat Stat_Damage;

    public float duration = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        float scale = Stat_Damage.Value;
        transform.localScale = new Vector3(scale, scale, scale);

        Destroy(gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(2 * Time.deltaTime, 0, 0);
    }
}
