public class PoisonEffect : CombatEffect
{
    public override EffectType effectType 
    { 
        get { return EffectType.EndOfTurn; }
    }
    public override string effectName
    {
        get { return "Poison"; }
    }

    public int stacks = 0;
    public int countdown = 3;

    public override void Activate(CharacterContainer characterContainer)
    {
        if (stacks != 5)
        {

        }

        int maxHealth = characterContainer.unit.GetMaxHealth();


        characterContainer.UpdateEffectVisuals(EffectVisual.Damage, 1);
    }

    public void AddStack()
    {
        stacks++;
        countdown = 3;
    }
}
