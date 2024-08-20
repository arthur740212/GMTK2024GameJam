using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclleDrop : MonoBehaviour
{
    private float duration = 1.0f;

    [SerializeField]
    private GameObject circleDropAttack;
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
        var pos = transform.position;
        var hitbox = Instantiate(circleDropAttack, pos, transform.rotation);
    }
}
