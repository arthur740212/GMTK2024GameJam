using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourBeams : MonoBehaviour
{
    private float duration = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Show the area of four Beams");
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
