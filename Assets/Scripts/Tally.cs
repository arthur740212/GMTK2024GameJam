using UnityEngine;
using UnityEngine.UI;

public class Tally : MonoBehaviour
{
    public float TallyScaleRate = 10.0f;
    public Material material;

    public Slider slider;
    public float sliderTargetValue;
    public float sliderCurrentValue;

    public float currentSize;
    public float targetSize;
    public Tally Initialized(CapType type)
    {
        Type = type;
        TypeAsInt = (int)type;
        return this;
    }

    private void Awake()
    {
        //pcc = gameObject.GetComponentInParent<PlayerCapContainer>();
        pcc.OnCollectedCapsChange += UpdateTallyVisual;
        //rectTransform = GetComponent<RectTransform>();  

        //MaterialPropertyBlock MPB = new();
        //MPB.SetColor("_Color", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
        //GetComponent<MeshRenderer>().SetPropertyBlock(MPB);
    }
    public bool PassedThreshold()
    {
        return Count >= Threshold;
    }

    private void UpdateTallyVisual()
    {
        //targetSize = pcc.TallyPerCapType[TypeAsInt].Count * TallyScaleRate;
        sliderTargetValue = (float)pcc.TallyPerCapType[TypeAsInt].Count / Threshold;


        //Vector3 pos = transform.localPosition;
        //pos.y = pcc.TallyPerCapType[TypeAsInt].Count * TallyScaleRate * 0.5f;
        //pos.x = -TypeAsInt;
        //transform.localPosition = pos;

        //Vector3 scale = transform.localScale;
        //scale.y = pcc.TallyPerCapType[TypeAsInt].Count * TallyScaleRate;
        //transform.localScale = scale;
    }

    private void Update()
    {
        //currentSize = rectTransform.sizeDelta.y;
        //targetSize = pcc.TallyPerCapType[TypeAsInt].Count * TallyScaleRate;
        //if (Mathf.Abs(currentSize - targetSize) > 0.001f)
        //{
        //    currentSize = 0.1f * targetSize + 0.9f * currentSize;
        //    rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, currentSize);
        //}


        sliderCurrentValue = slider.value;
        if (Mathf.Abs(sliderCurrentValue - sliderTargetValue) > 0.001f)
        {
            slider.value = Mathf.Lerp(sliderCurrentValue, sliderTargetValue, 0.1f);
        }

    }
    public int Count;
    public int Threshold = 3;
    public CapType Type;
    public int TypeAsInt;

    [SerializeField]
    private PlayerCapContainer pcc;
    private RectTransform rectTransform;
}
