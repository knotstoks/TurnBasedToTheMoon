using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    // The order which stuff is diaplayed should be: Poison, Burn, Blind, AttackChange, DefenseChange
    public Sprite[] effectSprites;
    public List<CombatEffect> effects = new List<CombatEffect>();
    public Unit unit;
    public void LoadUnit(Unit unitToLoad)
    {
        unit = unitToLoad;
    }
    public void ParseEndOfTurnEffects()
    {
        for (int i = 0; i < effects.Count; i++)
        {
            if (effects[i].effectType == EffectType.EndOfTurn)
            {
                effects[i].Activate(unit);
            }
        }
    }

    public void AddEffects(CombatEffect[] effectsToAdd)
    {
        for (int i = 0; i < effectsToAdd.Length; i++)
        {
            if (effectsToAdd[i].effectType != EffectType.Immediate)
            {
                switch (effectsToAdd[i].effectName) {
                    case "Poison":
                        break;
                    case "Burn":
                        break;
                    case "AttackChange":
                        break;
                    case "DefenseChange":
                        break;
                }
            }
        }
    }

    public void UpdateEffectVisuals()
    {

    }
}
