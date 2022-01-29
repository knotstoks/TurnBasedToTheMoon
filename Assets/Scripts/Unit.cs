using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] int currentHealth = 0;
    [SerializeField] int maxHealth = 0;
    [SerializeField] int speed = 0;
    [SerializeField] int power = 0;
    [SerializeField] bool friendly = true;

    [SerializeField] Skill skill_1;
    [SerializeField] Skill skill_2;
    [SerializeField] Skill skill_3;
    [SerializeField] Skill skill_4;

    public Skill[] getSkills()
    {
        Skill[] skillList = { skill_1, skill_2, skill_3, skill_4 };
        return skillList;
    }

    public bool getFriendly()
    {
        return friendly;
    }

    public int getSpeed()
    {
        return speed;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
