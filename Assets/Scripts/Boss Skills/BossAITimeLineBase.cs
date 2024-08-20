using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class BossAITimeLineBase : MonoBehaviour
{
    [SerializeField]
    private GameObject arena;

    [SerializeField]
    private GameObject halfBladePrefab;
    
    [SerializeField]
    private GameObject AOEPrefab;
    
    [SerializeField]
    private GameObject FourBeamsPrefab;
    
    [SerializeField]
    private GameObject DropPrefab;

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
        Vector3 halfbladeCenter1 = (A10+ A11 + A14 + A15)/4.0f;
        halfbladeCenter1.y = arena.transform.position.y;
        Vector3 A2 = arena.transform.GetChild(1).transform.position;
        Vector3 A3 = arena.transform.GetChild(2).transform.position;
        Vector3 A6 = arena.transform.GetChild(5).transform.position;
        Vector3 A7 = arena.transform.GetChild(6).transform.position;
        Vector3 halfbladeCenter2 = (A2 + A3 + A6 + A7) / 4.0f;
        halfbladeCenter2.y = arena.transform.position.y;

        int randNum = Random.Range(0, 2);
        
        if(randNum == 0)
        {
            Instantiate(halfBladePrefab, halfbladeCenter1, transform.rotation);
        }
        else
        {
            Instantiate(halfBladePrefab, halfbladeCenter2, transform.rotation);
        }
    }

    public void AOE()
    {
        Instantiate(AOEPrefab, Vector3.zero, transform.rotation);
    }

    public void FourBeamsIndicator()
    {
        Vector3 A1 = arena.transform.GetChild(0).transform.position;
        Vector3 A5 = arena.transform.GetChild(4).transform.position;
        Vector3 A9 = arena.transform.GetChild(8).transform.position;
        Vector3 A13 = arena.transform.GetChild(12).transform.position;


        int randNum = Random.Range(0, 4);
        Debug.Log("Do four beams");
        
        if (randNum == 0)
        {
            Debug.Log("Do four beams with random number : " + randNum);
            Instantiate(FourBeamsPrefab, A1, transform.rotation);
            StartCoroutine(DelayCreateBeams(A5,0.75f));
            StartCoroutine(DelayCreateBeams(A9, 1.5f));
            StartCoroutine(DelayCreateBeams(A13, 2.25f));
        }
        else if(randNum == 1)
        {
            Debug.Log("Do four beams with random number : " + randNum);
            Instantiate(FourBeamsPrefab, A5, transform.rotation);
            StartCoroutine(DelayCreateBeams(A9, 1.0f));
            StartCoroutine(DelayCreateBeams(A1, 2.0f));
            StartCoroutine(DelayCreateBeams(A13, 3.0f));
        }
        else if (randNum == 2)
        {
            Debug.Log("Do four beams with random number : " + randNum);
            Instantiate(FourBeamsPrefab, A9, transform.rotation);
            StartCoroutine(DelayCreateBeams(A1, 1.0f));
            StartCoroutine(DelayCreateBeams(A13, 2.0f));
            StartCoroutine(DelayCreateBeams(A5, 3.0f));
        }
        else
        {
            Debug.Log("Do four beams with random number : " + randNum);
            Instantiate(FourBeamsPrefab, A13, transform.rotation);
            StartCoroutine(DelayCreateBeams(A9,1.0f));
            StartCoroutine(DelayCreateBeams(A5,2.0f));
            StartCoroutine(DelayCreateBeams(A1, 3.0f));
        }
    }

    IEnumerator DelayCreateBeams(Vector3 pos, float delaytime)
    {
        yield return new WaitForSeconds(delaytime);
        Instantiate(FourBeamsPrefab, pos, transform.rotation);
    }



    public void SpiralWeaveIndicator()
    {
        Vector3 A1 = arena.transform.GetChild(0).transform.position;
        Vector3 A2 = arena.transform.GetChild(1).transform.position;
        Vector3 A3 = arena.transform.GetChild(2).transform.position;
        Vector3 A4 = arena.transform.GetChild(3).transform.position;
        Vector3 A5 = arena.transform.GetChild(4).transform.position;
        Vector3 A6 = arena.transform.GetChild(5).transform.position;
        Vector3 A7 = arena.transform.GetChild(6).transform.position;
        Vector3 A8 = arena.transform.GetChild(7).transform.position;
        Vector3 A9 = arena.transform.GetChild(8).transform.position;
        Vector3 A10 = arena.transform.GetChild(9).transform.position;
        Vector3 A11 = arena.transform.GetChild(10).transform.position;
        Vector3 A12 = arena.transform.GetChild(11).transform.position;
        Vector3 A13 = arena.transform.GetChild(12).transform.position;
        Vector3 A14 = arena.transform.GetChild(13).transform.position;
        Vector3 A15 = arena.transform.GetChild(14).transform.position;
        Vector3 A16 = arena.transform.GetChild(15).transform.position;


        int randNum = Random.Range(0, 2);
        Debug.Log("Do Spiral Weaves");

        if (randNum == 0)
        {
            Instantiate(DropPrefab, A1, transform.rotation);
            StartCoroutine(DelayCreateDrops(A2, 0.2f));
            StartCoroutine(DelayCreateDrops(A3, 0.4f));
            StartCoroutine(DelayCreateDrops(A4, 0.6f));

            StartCoroutine(DelayCreateDrops(A8, 0.8f));
            StartCoroutine(DelayCreateDrops(A12, 1.0f));

            StartCoroutine(DelayCreateDrops(A16, 1.2f));
            StartCoroutine(DelayCreateDrops(A15, 1.4f));
            StartCoroutine(DelayCreateDrops(A14, 1.6f));
            StartCoroutine(DelayCreateDrops(A13, 1.8f));

            StartCoroutine(DelayCreateDrops(A9, 2.0f));
            StartCoroutine(DelayCreateDrops(A5, 2.2f));

            StartCoroutine(DelayCreateDrops(A6, 2.4f));
            StartCoroutine(DelayCreateDrops(A7, 2.6f));

            StartCoroutine(DelayCreateDrops(A11, 2.8f));
            StartCoroutine(DelayCreateDrops(A10, 3.0f));
        }
        else
        {
            Instantiate(DropPrefab, A10, transform.rotation);
            StartCoroutine(DelayCreateDrops(A11, 0.2f));
            
            StartCoroutine(DelayCreateDrops(A7, 0.4f));
            StartCoroutine(DelayCreateDrops(A6, 0.6f));

            StartCoroutine(DelayCreateDrops(A5, 0.8f));
            StartCoroutine(DelayCreateDrops(A9, 1.0f));

            StartCoroutine(DelayCreateDrops(A13, 1.2f));
            StartCoroutine(DelayCreateDrops(A14, 1.4f));
            StartCoroutine(DelayCreateDrops(A15, 1.6f));
            StartCoroutine(DelayCreateDrops(A16, 1.8f));

            StartCoroutine(DelayCreateDrops(A12, 2.0f));
            StartCoroutine(DelayCreateDrops(A8, 2.2f));

            StartCoroutine(DelayCreateDrops(A4, 2.4f));
            StartCoroutine(DelayCreateDrops(A3, 2.6f));
            StartCoroutine(DelayCreateDrops(A2, 2.8f));
            StartCoroutine(DelayCreateDrops(A1, 3.0f));
        }
    }

    IEnumerator DelayCreateDrops(Vector3 pos, float delaytime)
    {
        yield return new WaitForSeconds(delaytime);
        Instantiate(DropPrefab, pos, transform.rotation);
    }
}
