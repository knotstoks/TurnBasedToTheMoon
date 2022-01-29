using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillTypes
{
    Blunt,
    Sharp,
    Magic,
    None
}


public class Skill : MonoBehaviour
{
    [SerializeField] string skillName = "Placeholder Name";
    [SerializeField] int power = 0;
    [SerializeField] int range = 1;
    [SerializeField] CombatEffects[] combatEffects = { };
    [SerializeField] SkillTypes skillType = SkillTypes.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
