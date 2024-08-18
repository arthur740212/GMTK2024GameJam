using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class HatGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] HatPrefab;

    [SerializeField]
    private GameObject[] AreaBlockGameObjects;

    private int posIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GenerateHatRandomly();
        }
    }

    private void GenerateHatRandomly()
    {
        posIndex = Random.Range(0, 16);
        var Pos = AreaBlockGameObjects[posIndex].transform.position;
        Pos.y = 0.5f;
        var hat = Instantiate(HatPrefab[0], Pos, transform.rotation); ;
    }

}
