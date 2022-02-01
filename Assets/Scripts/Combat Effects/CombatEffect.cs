using UnityEngine;

public enum EffectType { Immediate, EndOfTurn, StatChange}
public abstract class CombatEffect : MonoBehaviour
{
    public EffectType effectType;
    public string effectName;
    public abstract void Activate(Unit unit);
}
