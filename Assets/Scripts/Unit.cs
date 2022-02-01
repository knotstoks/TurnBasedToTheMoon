using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private int currentHealth = 0;
    [SerializeField] private int maxHealth = 0;
    [SerializeField] private int speed = 0;
    [SerializeField] private int power = 0;
    [SerializeField] private bool friendly = true;

    [SerializeField] private Skill[] skills = new Skill[4];

    public Skill[] GetSkills()
    { 
        return skills;
    }

    public bool GetFriendly()
    {
        return friendly;
    }

    public void SetFriendly(bool state)
    {
        friendly = state;
    }

    public int GetSpeed()
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
