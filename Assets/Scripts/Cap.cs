using UnityEngine;

public enum CapType
{
    Red,
    Green,
    Yellow,
    Blue,
}

public class Cap : MonoBehaviour
{
    public Cap Initialized(int index)
    {
        Type = (CapType)index;
        return this;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerCapContainer>().AddCap(this);
        capCollider.enabled = false;
        mover.enabled = true;
    }

    public Collider capCollider;
    public Move3DObjectToUI mover;
    public CapType Type;
}
