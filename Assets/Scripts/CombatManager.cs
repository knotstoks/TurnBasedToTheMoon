using UnityEngine;
using TMPro;

public class CombatManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameLogic gameLogic;
    private Unit currentUnit;
    private Unit targetUnit; // TODO: Change to List<Unit>

    private bool validTarget;



    [SerializeField] private GameObject[] skillUI = new GameObject[4];
    private Skill[] skills = { };
    private int selectedSkill;


    void Start()
    {
        gameLogic = GetComponent<GameLogic>();
    }

    public void TakeTurn(Unit unit)
    {
        currentUnit = unit;
        skills = currentUnit.GetSkills();

        selectedSkill = -1; // Clear default selection
        InitialiseUI();
    }

    private void InitialiseUI()
    {
        for (int i = 0; i < 4; i++)
        {
            TextMeshProUGUI skillText = skillUI[i].GetComponent<TextMeshProUGUI>();
            if (skills[i] != null)
                skillText.SetText(skills[i].GetSkillname());
        }
    }


    public void OnSkillSelect(int skillNumber)
    {
        Debug.Log("clickedSkill" + skillNumber);
        if (skillNumber == selectedSkill && validTarget)
        {
            DeliverSkill(skillNumber);
        }
        else
        {
            selectedSkill = skillNumber;
            Targetting(selectedSkill);
        }
    }


    private void Targetting(int skillNumber)
    {
        int skillRange = skills[skillNumber].GetRange();
        int currentPos = gameLogic.GetPosition(currentUnit); // Returns an int 0 - 3 depending on unit's position
        int targetPos;
        if (currentPos - skillRange < 0) // Valid and targetting some enemy // TODO: Fix this
        {
            targetPos = skillRange - currentPos - 1;
            Debug.Log("Skill has range " + skillRange + ", playerPos is " + currentPos + "and targetPos is " + targetPos);
            targetUnit = gameLogic.GetUnit(targetPos, false);
            ShowTargettingUI();
            validTarget = true;
        }
        else
        {
            validTarget = false;
            Debug.Log(currentUnit + " cannot hit anyone with this skill");
            //Grey out skill or smth
        }
    }


    private void ShowTargettingUI()
    {
        Debug.Log(currentUnit + " is targetting " + targetUnit);
        //display stuff with currentUnit and targetUnit
    }


    private void DeliverSkill(int skillNumber)
    {
        string skillName = skills[skillNumber].GetSkillname();
        int power = skills[skillNumber].GetPower();


        Debug.Log(currentUnit + " attacks " + targetUnit + " with " + skillName + " at " + power + "%power!"); //to implement


        gameLogic.FinishedTurn(currentUnit);
    }
}
