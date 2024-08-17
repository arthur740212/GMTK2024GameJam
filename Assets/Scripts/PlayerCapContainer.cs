using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCapContainer : MonoBehaviour
{
    public event Action OnCollectedCapsChange;
    public int Capacity { get { return capacity; } }
    public List<Cap> CollectedCaps { get { return collectedCaps; } }
    public Dictionary<CapType, int> CountPerCapType { get { return countPerCapType; } }

    public void AddCap(Cap pickedUpCap)
    {
        if (collectedCaps.Count < capacity)
        {
            collectedCaps.Add(pickedUpCap);       
            CollectedCapsUpdate();
        }
    }

    public void AddRandomCap()
    {
        if (collectedCaps.Count < capacity)
        {
            int capType = UnityEngine.Random.Range(0, Enum.GetNames(typeof(CapType)).Length);
            AddCap(new GameObject().AddComponent<Cap>().Initialized(capType));
        }
    }

    public void FlushCapType(CapType type)
    {
        foreach (var cap in collectedCaps)
        {
            if (cap.Type == type) 
            {
                collectedCaps.Remove(cap);
            }
        }

        CollectedCapsUpdate();
    } 

    [SerializeField]
    private int capacity = 10;
    [SerializeField]
    private List<Cap> collectedCaps = new();
    [SerializeField]
    private Dictionary<CapType, int> countPerCapType = new();
    private void Awake()
    {
        foreach (var type in EnumHelper.GetEnumList<CapType>())
        {
            countPerCapType[type] = 0;
        }
    }

    private void CollectedCapsUpdate()
    {
        TallyCollectedCaps();
        OnCollectedCapsChange();
    }

    private void TallyCollectedCaps()
    {
        foreach (var type in EnumHelper.GetEnumList<CapType>())
        { 
            countPerCapType[type] = 0;
        }
        foreach (var cap in collectedCaps)
        {
            countPerCapType[cap.Type] += 1;
        }
    }
}
