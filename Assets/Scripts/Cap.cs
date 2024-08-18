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

    public CapType Type;
}
