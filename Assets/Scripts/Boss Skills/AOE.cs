using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    public int damage = 200;
    private float duration = 3.0f;
    //do collision check
    //do dmg
    //destroy self
    // Start is called before the first frame update


    void Start()
    {
        Debug.Log("Do AOE dmg");
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.GetChild(0).gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        Destroy(gameObject, duration);
    }

    void OnDestroy()
    {
        Debug.Log("Do damage");
        //Instantiate(halfBladeAttack, Boss.transform);
        GameObject player = GameObject.Find("Player");
        PlayerStats playerStat = null;
        if (player != null)
        {
            playerStat = player.GetComponent<PlayerStats>();
        }

        if (playerStat != null)
        {
            playerStat.LoseHealth(damage);
        }
    }
}
