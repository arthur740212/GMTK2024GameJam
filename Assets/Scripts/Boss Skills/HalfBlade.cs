using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfBlade : MonoBehaviour
{
    private float duration = 3.0f;

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
        Debug.Log("Do damage");
        //Instantiate(halfBladeAttack, Boss.transform);
    }
}
