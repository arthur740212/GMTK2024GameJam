using System;
using UnityEngine;
using static HatGenerator;

public enum CapType
{
    Red,
    Green,
    Yellow,
    Blue,
}

public class Cap : MonoBehaviour
{

    [SerializeField]
    private GameObject arena;

    private float duration = 10.0f;

    public int posIndex = -1;

    HatGenerator hatGenerator = null;

    void Start()
    {
        hatGenerator = arena.GetComponent<HatGenerator>();
    }
    public Cap Initialized(int index)
    {
        Type = (CapType)index;
        return this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mover.OnMoveComplete += () => other.gameObject.GetComponent<PlayerCapContainer>().AddCap(this);

            //capCollider.enabled = false;
            mover.enabled = true;
        }
    }

    public Collider capCollider;
    public Move3DObjectToUI mover;
    public CapType Type;

    void Update()
    {
        Destroy(gameObject, duration);
    }

    void OnDestroy()
    {
        hatGenerator.hatPosArray[posIndex].isOccupied = false;
    }
}
