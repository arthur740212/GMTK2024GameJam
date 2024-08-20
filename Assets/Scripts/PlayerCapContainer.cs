using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCapContainer : MonoBehaviour
{
    public event Action OnCollectedCapsChange;

    public PlayerStats playerStats;
    public int Capacity { get { return capacity; } }
    public List<Cap> CollectedCaps { get { return collectedCaps; } }
    public List<Tally> TallyPerCapType { get { return tallyPerCapType; } }

    public Tally TallyPrefab;

    public Image Cloth;

    public void AddCap(Cap pickedUpCap)
    {
        if (collectedCaps.Count < capacity)
        {
            collectedCaps.Add(pickedUpCap);
            playerStats.Pickup(pickedUpCap.Type);

            CollectedCapsUpdate();
            CheckOverflowedSets();

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

    private Color updatedColor;
    public async void DecideLevelUp()
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

        switch (upgradeTypeTally.Type)
        {
            case CapType.Red:
                updatedColor = Color.red;
                break;
            case CapType.Green:
                updatedColor = Color.green;
                break;
            case CapType.Yellow:
                updatedColor = Color.yellow;
                break;
            case CapType.Blue:
                updatedColor = Color.blue;
                break;
        }

        ChangeColor();
        await Task.Delay(400);
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
        ResetColor();
    }

    public Color defaultClothColor;
    public Color dissolveClothColor;
    private bool changeInProcess = false;
    public async void ResetColor()
    {
        float t = 0.0f;
        while (changeInProcess) 
        {
            await Task.Delay(1);
        }
        while (t < 1.0f)
        {
            t += Time.deltaTime;
            Cloth.color = Color.Lerp(Cloth.color, defaultClothColor, t);
            await Task.Delay(1);
        }
    }

    public async void ChangeColor()
    {
        changeInProcess = true;
        float t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime;
            Cloth.color = Color.Lerp(Cloth.color, updatedColor, t);
            await Task.Delay(1);
        }
        changeInProcess = false;
    }

    public async void CheckOverflowedSets()
    {
        foreach (var tally in tallyPerCapType)
        {
            if (tally.PassedThreshold())
            {
                updatedColor = dissolveClothColor;
                ChangeColor();
                await Task.Delay(400);
                FlushAllCaps();
                return;
            }
        }
        if (collectedCaps.Count == capacity)
        {
            DecideLevelUp();
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
