using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfBlade : MonoBehaviour
{
    private float duration = 3.0f;

    [SerializeField]
    private GameObject halfBladeAttack;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Show the area of Half Blade");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, duration);
    }

    void OnDestroy()
    {
        Debug.Log("Do HalfBlade damage");
        var pos = transform.position;
        var hitbox= Instantiate(halfBladeAttack, pos, transform.rotation);
    }
}
