using UnityEngine;

public enum CapType
{
    Blue,
    Red,
    Yellow
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
