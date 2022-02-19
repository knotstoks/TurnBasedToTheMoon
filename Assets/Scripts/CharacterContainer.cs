using System.Collections.Generic;
using UnityEngine;

public enum EffectVisual
{
    Damage, Buff, Debuff
}

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
                effects[i].Activate(this);
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
                        PoisonEffect poisonEffect = null;
                        for (int j = 0; i < effects.Count; j++)
                        {
                            if (effects[j].effectName.Equals("Poison"))
                            {
                                poisonEffect = (PoisonEffect) effects[j];
                                poisonEffect.AddStack();
                                break;
                            }
                        }

                        if (poisonEffect == null)
                        {
                            poisonEffect = new PoisonEffect();
                            effects.Add(poisonEffect);
                        }


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

    public void UpdateEffectVisuals(EffectVisual effectVisual, int n)
    {

    }
}
