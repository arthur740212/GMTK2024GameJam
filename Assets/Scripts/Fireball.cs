using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class Fireball : MonoBehaviour
{

    public GameObject target;
    //Vector3 targetPos = new Vector3(0.0f, 0.0f, 40.0f);
    
    public Stat Stat_Damage;
    

    public float duration = 10.0f;
    public float speed = 5.0f;
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
        transform.position += speed * Time.deltaTime * (target.transform.position - transform.position);
    }
}
