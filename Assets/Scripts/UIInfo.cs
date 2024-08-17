using System.Collections.Generic;
using UnityEngine;

public class UIInfo : MonoBehaviour
{
    public GameObject TallyPrefab;
    private List<Transform> tallyTranforms = new();

    public float TallyScaleRate = 2.0f;
    private void Awake()
    {
        pcc = gameObject.GetComponent<PlayerCapContainer>();       
        pcc.OnCollectedCapsChange += UpdateTallyVisual;

        foreach (var typeCount in pcc.CountPerCapType)
        {
            tallyTranforms.Add(Instantiate(TallyPrefab, transform).transform);
        }
    }
    private void UpdateTallyVisual()
    {
        for (int i = 0; i < pcc.CountPerCapType.Count; i++)
        {
            Vector3 pos = tallyTranforms[i].localPosition;
            pos.x = -10 + pcc.CountPerCapType[(CapType)i] * TallyScaleRate * 0.5f;
            pos.y = -i;
            tallyTranforms[i].localPosition = pos;

            Vector3 scale = tallyTranforms[i].localScale;
            scale.x = pcc.CountPerCapType[(CapType)i] * TallyScaleRate;
            tallyTranforms[i].localScale = scale;
        }
    }

    [SerializeField]
    private PlayerCapContainer pcc;
}
