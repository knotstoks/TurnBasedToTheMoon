using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillTypes
{
    Blunt,
    Sharp,
    Magic,
    Normal
}


public class Skill : MonoBehaviour
{
    [SerializeField] private string skillName = "Placeholder Name";
    [SerializeField] private int power  = 0;
    [SerializeField] private int range = 1;
    [SerializeField] private CombatEffects[] combatEffects  = { };
    [SerializeField] private SkillTypes skillType = SkillTypes.Normal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetSkillname()
    {
        return skillName;
    }

    public int GetPower()
    {
        return power;
    }

    public int GetRange()
    {
        return range;
    }

    public CombatEffects[] GetCombatEffects()
    {
        return combatEffects;
    }

    public SkillTypes GetSkillType()
    {
        return skillType;
    }

}
