using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class HatGenerator : MonoBehaviour
{

    public struct HatPos
    {
        public Vector3 pos;
        public bool isOccupied;
    };

    public HatPos[] hatPosArray = new HatPos[16];

    private float timepass = 0.0f;

    [SerializeField]
    private GameObject[] hatPrefab;

    [SerializeField]
    private GameObject arena;

    [SerializeField]
    private GameObject[] areaBlockGameObjects;

    private int posIndex = 0;
    private int hatIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < 16 ;i++)
        {
            hatPosArray[i].pos = areaBlockGameObjects[i].transform.position;
            hatPosArray[i].isOccupied = false;
        }

        GenerateHatRandomly(0,4);
        GenerateHatRandomly(4,8);
        GenerateHatRandomly(8,12);
        GenerateHatRandomly(12,16);
    }

    // Update is called once per frame
    void Update()
    {
        timepass += Time.deltaTime;
        if(timepass >= 2.0f)
        {
            GenerateHatRandomly(0,16);
            timepass = 0.0f;
        }
    }

    private void GenerateHatRandomly(int minValue, int maxValue)
    {
        posIndex = Random.Range(minValue, maxValue);
        hatIndex = Random.Range(0, 4);
        
        //while(hatPosArray[posIndex].isOccupied == true)
        //{
        //    Debug.Log("the pos already obtained a hat");
        //    posIndex++;
        //    if(posIndex > 15)
        //    {
        //        posIndex = 0;
        //    }
        //}
        var Pos = hatPosArray[posIndex].pos;
        hatPosArray[posIndex].isOccupied = true;

        Pos.y = arena.transform.position.y + 0.5f;
        GameObject hat = Instantiate(hatPrefab[hatIndex], Pos, transform.rotation);
        Cap hatStat =  hat.GetComponent<Cap>();
        hatStat.posIndex = posIndex;
    }

    IEnumerator DelayCreateHatRandomly(float delaytime)
    {
        yield return new WaitForSeconds(delaytime);
        GenerateHatRandomly(0,16);
    }

}
