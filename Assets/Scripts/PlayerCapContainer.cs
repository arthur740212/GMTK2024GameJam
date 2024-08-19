using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCapContainer : MonoBehaviour
{
    public event Action OnCollectedCapsChange;

    public PlayerStats playerStats;
    public int Capacity { get { return capacity; } }
    public List<Cap> CollectedCaps { get { return collectedCaps; } }
    public List<Tally> TallyPerCapType { get { return tallyPerCapType; } }

    public Tally TallyPrefab;

    public void AddCap(Cap pickedUpCap)
    {
        if (collectedCaps.Count < capacity)
        {
            collectedCaps.Add(pickedUpCap);
            playerStats.Pickup(pickedUpCap.Type);

            CollectedCapsUpdate();
            CheckOverflowedSets();

            if (collectedCaps.Count == capacity)
            {
                DecideLevelUp();
            }
            //CheckCompletedSets();
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


    public void DecideLevelUp()
    {
        int highestCount = 0;
        List<int> highestTypes = new();

        for (int i = 0; i < TallyPerCapType.Count; i++)
        {
            if (TallyPerCapType[i].Count > highestCount)
            {
                highestCount = TallyPerCapType[i].Count;
                highestTypes.Clear();
                highestTypes.Add(i);
            }
            else if (TallyPerCapType[i].Count == highestCount)
            {
                highestTypes.Add(i);
            }
        }

        Tally upgradeTypeTally = TallyPerCapType[highestTypes[UnityEngine.Random.Range(0, highestTypes.Count)]];
        highestTypes.Clear();
        playerStats.LevelUp(upgradeTypeTally.Type);
        WearCap(upgradeTypeTally.TypeAsInt);

        FlushAllCaps();

    }

    public List<GameObject> capModels;
    private int WornCapCount = 0;
    public float spacing = 0.2f;
    public float playerHeadPosY = 1.8f;

    public void WearCap(int TypeAsInt) 
    {
        Vector3 pos = Vector3.zero;
        pos.y = playerHeadPosY + WornCapCount * spacing;
        var newCap = Instantiate(capModels[TypeAsInt], transform);
        newCap.transform.localPosition = pos;
        WornCapCount++;
    }

    public void FlushAllCaps()
    {
        for (int i = collectedCaps.Count - 1; i >= 0; i--)
        {
            Destroy(collectedCaps[i].gameObject);
            collectedCaps.Remove(collectedCaps[i]);
        }

        CollectedCapsUpdate();

    }

    public void CheckOverflowedSets()
    {
        foreach (var tally in tallyPerCapType)
        {
            if (tally.PassedThreshold())
            {
                FlushAllCaps();
                return;
            }
        }
    }

    public void CheckCompletedSets() 
    {
        foreach (var tally in tallyPerCapType) 
        {
            if (tally.PassedThreshold()) 
            {
                FlushCompletedSet(tally.Type);
                playerStats.LevelUp(tally.Type);
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
        if (playerStats == null)
        {
            playerStats = gameObject.AddComponent<PlayerStats>();
        }
        //foreach (var type in EnumHelper.GetEnumList<CapType>())
        //{
        //    tallyPerCapType.Add(Instantiate(TallyPrefab, transform).Initialized(type));
        //}
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
