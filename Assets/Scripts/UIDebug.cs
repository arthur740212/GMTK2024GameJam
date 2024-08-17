using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDebug : MonoBehaviour
{
    public PlayerCapContainer pcc;
    public Button Button_AddRandomCap;
    public List<Text> TypeCounts = new();

    private void Awake()
    {
        Button_AddRandomCap.onClick.AddListener(pcc.AddRandomCap);
        foreach (var typeCount in pcc.CountPerCapType)
        {
            TypeCounts.Add(Instantiate(new GameObject("TypeCountText"),transform).AddComponent<Text>());
        }
        pcc.OnCollectedCapsChange += UpdateText;
    }
    private void UpdateText()
    { 
        for (int i = 0; i < TypeCounts.Count; i++) 
        {
            TypeCounts[i].text = $"{(CapType)i} : {pcc.CountPerCapType[(CapType)i]}";
        }
    }
}
