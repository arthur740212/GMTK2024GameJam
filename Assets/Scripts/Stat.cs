using UnityEngine;

[CreateAssetMenu]
public class Stat : ScriptableObject
{
    public float Value { get { return curve.Evaluate(level); } }

    [SerializeField]
    private AnimationCurve curve;

    public int level = 1;
}