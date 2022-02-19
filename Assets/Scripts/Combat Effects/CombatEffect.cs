using UnityEngine;

public enum EffectType { Immediate, EndOfTurn, StatChange}
public abstract class CombatEffect : MonoBehaviour
{
    public virtual EffectType effectType {get; set;}
    public virtual string effectName {get; set;}
    public abstract void Activate(CharacterContainer characterContainer);
}
