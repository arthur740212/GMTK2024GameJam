using UnityEngine;

public class Tally : MonoBehaviour
{
    public float TallyScaleRate = 2.0f;
    public Material material;
    public Tally Initialized(CapType type)
    {
        Type = type;
        TypeAsInt = (int)type;
        return this;
    }

    private void Awake()
    {
        pcc = gameObject.GetComponentInParent<PlayerCapContainer>();
        pcc.OnCollectedCapsChange += UpdateTallyVisual;

        MaterialPropertyBlock MPB = new();
        MPB.SetColor("_Color", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        GetComponent<MeshRenderer>().SetPropertyBlock(MPB);
    }
    public bool PassedThreshold()
    {
        return Count >= Threshold;
    }

    private void UpdateTallyVisual()
    {
        Vector3 pos = transform.localPosition;
        pos.x = -10 + pcc.TallyPerCapType[TypeAsInt].Count * TallyScaleRate * 0.5f;
        pos.y = -TypeAsInt;
        transform.localPosition = pos;

        Vector3 scale = transform.localScale;
        scale.x = pcc.TallyPerCapType[TypeAsInt].Count * TallyScaleRate;
        transform.localScale = scale;
    }

    public int Count;
    public int Threshold = 3;
    public CapType Type;
    public int TypeAsInt;

    [SerializeField]
    private PlayerCapContainer pcc;
}
