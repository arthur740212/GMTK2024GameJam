using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfBlade : MonoBehaviour
{
    private float duration = 1.0f;
    [SerializeField]
    private GameObject Boss;

    [SerializeField]
    private GameObject halfBladeAttack;
    //do collision check
    //do dmg
    //destroy self





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
