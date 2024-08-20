using UnityEngine;

[CreateAssetMenu]
public class Stat : ScriptableObject
{
    public float Evaluate(int level) { return curve.Evaluate(level); }

    [SerializeField]
    private AnimationCurve curve;

    //public int level = 1;
}