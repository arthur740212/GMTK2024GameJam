using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCapContainer : MonoBehaviour
{
    public event Action OnCollectedCapsChange;
    public int Capacity { get { return capacity; } }
    public List<Cap> CollectedCaps { get { return collectedCaps; } }
    public List<Tally> TallyPerCapType { get { return tallyPerCapType; } }

    public Tally TallyPrefab;

    public void AddCap(Cap pickedUpCap)
    {
        if (collectedCaps.Count < capacity)
        {
            collectedCaps.Add(pickedUpCap);
            CollectedCapsUpdate();
            CheckCompletedSets();
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

    public void CheckCompletedSets() 
    {
        foreach (var tally in tallyPerCapType) 
        {
            if (tally.PassedThreshold()) 
            {
                FlushCompletedSet(tally.Type);
                
            }
        }
    }

    public void FlushCompletedSet(CapType type)
    {
        for (int i = collectedCaps.Count - 1; i >= 0; i--)
        {
            if (collectedCaps[i].Type == type)
            {
                Destroy(collectedCaps[i].gameObject);
                collectedCaps.Remove(collectedCaps[i]);
            }
        }
        CollectedCapsUpdate();
    } 

    [SerializeField]
    private int capacity = 10;
    [SerializeField]
    private List<Cap> collectedCaps = new();
    [SerializeField]
    private List<Tally> tallyPerCapType = new();
    private void Awake()
    {
        foreach (var type in EnumHelper.GetEnumList<CapType>())
        {
            tallyPerCapType.Add(Instantiate(TallyPrefab, transform).Initialized(type));
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
            tallyPerCapType[(int)type].Count = 0;
        }
        foreach (var cap in collectedCaps)
        {
            tallyPerCapType[(int)cap.Type].Count += 1;
        }
    }
}
