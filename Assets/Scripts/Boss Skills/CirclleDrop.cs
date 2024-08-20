using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclleDrop : MonoBehaviour
{
    private float duration = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Show the area of circle drop");
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
