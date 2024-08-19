using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class Fireball : MonoBehaviour
{
    public GameObject target;
    public int damage = 2;
    public float sizeRate = 1.0f;


    public float duration = 10.0f;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        float scale = sizeRate;
        transform.localScale = new Vector3(scale, scale, scale);
        Destroy(gameObject, duration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * (target.transform.position - transform.position);
    }
}
