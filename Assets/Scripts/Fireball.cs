using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class Fireball : MonoBehaviour
{

    public Stat sizeStats;

    public GameObject target;
    public int damage = 1;

    public float duration = 10.0f;
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        float scale = sizeStats.Evaluate(damage);
        transform.localScale = new Vector3(scale, scale, scale);
        Destroy(gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * (target.transform.position - transform.position);
    }
}
