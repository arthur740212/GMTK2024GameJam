using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAITimeLineBase : MonoBehaviour
{
    [SerializeField]
    private GameObject arena;

    [SerializeField]
    private GameObject halfBladePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //string name = arena.transform.GetChild(0).name;
        //Debug.Log(name);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) 
        {
            Debug.Log("Cast half blade");
            HalfBladeIndicator();
        }
    }

    public void HalfBladeIndicator()
    {
        Vector3 A10 = arena.transform.GetChild(9).transform.position;
        Vector3 A11 = arena.transform.GetChild(10).transform.position;
        Vector3 A14 = arena.transform.GetChild(13).transform.position;
        Vector3 A15 = arena.transform.GetChild(14).transform.position;

        Vector3 halfbladeCenter = (A10+ A11 + A14 + A15)/4.0f;
        halfbladeCenter.y = 0.1f;

        Instantiate(halfBladePrefab, halfbladeCenter,transform.rotation);
    }
}
