using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, TRANSITION, PAUSED }
    private BattleState battleState;

    [SerializeField] private Party playerParty;
    private Unit[] playerUnits;
    [SerializeField] private Party enemyParty;
    private Unit[] enemyUnits;
    private Unit currentUnit = null;

    [SerializeField] private CombatManager combatManager;

    [SerializeField] private Transform[] characterLocations = new Transform[8]; // TODO: Should be hard coded, we adjust when we get the sprites in
    private int[] actionSpeedArray = { 0, 0, 0, 0, 0, 0, 0, 0 };
    private int[] actionValueArray = { 0, 0, 0, 0, 0, 0, 0, 0 };

    void Start() // Where are your access modifiers >:(
    {
        battleState = BattleState.START;
        LoadAllUnits();
        battleState = BattleState.TRANSITION;
    }

    void Update()
    {
        if (battleState == BattleState.TRANSITION)
        {
            currentUnit = CheckActionValue();
            if (currentUnit != null)
            {
                if (currentUnit.GetFriendly())
                    battleState = BattleState.PLAYERTURN;
                else
                    battleState = BattleState.ENEMYTURN;

            }
            else 
                UpdateActionValue();
        }

        if (battleState == BattleState.PLAYERTURN)
        {
            battleState = BattleState.PAUSED;
            Debug.Log("Friendly " + currentUnit.gameObject.name + " is taking his turn!");
            combatManager.TakeTurn(currentUnit);
        }

        if (battleState == BattleState.ENEMYTURN)
        {
            battleState = BattleState.PAUSED;
            Debug.Log("Enemy " + currentUnit.gameObject.name + " is taking his turn!");
            // Pass to EnemyController
        }


    }

    // Called once on initialising combat scene
    private void LoadAllUnits()
    {
        playerUnits = playerParty.getActiveUnitList();
        enemyUnits = enemyParty.getActiveUnitList();

        // Player
        int partySize = playerUnits.Length;
        for (int i = 0; i < partySize; i++)
        {
            Instantiate(playerUnits[i], characterLocations[i].position, Quaternion.identity);
            playerUnits[i].SetFriendly(true);
            actionSpeedArray[i] = playerUnits[i].GetSpeed();
        }

        // Enemies
        partySize = enemyUnits.Length;
        for (int i = 0; i < partySize; i++)
        {
            Instantiate(enemyUnits[i], characterLocations[i + 4].position, Quaternion.Euler(0, 180, 0));
            enemyUnits[i].SetFriendly(false);
            actionSpeedArray[i + 4] = enemyUnits[i].GetSpeed();
        }
    }

    private void UpdateActionValue()
    {
        for (int i = 0; i < 8; i++)
        {
            actionValueArray[i] += actionSpeedArray[i];
        }
    }

    private Unit CheckActionValue()
    {
        for (int i = 0; i < 8; i++)
        {
            if (actionValueArray[i] >= 100)
            {
                if (i < 4) {
                    return playerUnits[i];
                }
                else
                {
                    return enemyUnits[i - 4];
                }
            }
        }
        return null;
    }


    public void FinishedTurn(Unit unit) //reset speed and switch to transition
    {
        int pos = GetPosition(unit);
        int arrayPos;
        if (unit.GetFriendly())
            arrayPos = 3 - pos;
        else
            arrayPos = pos + 4;
        actionValueArray[arrayPos] = 0;
        battleState = BattleState.TRANSITION;
    }


    public int GetPosition(Unit unit)
    {
        Unit[] units;
        if (unit.GetFriendly())
            units = playerUnits;
        else
            units = enemyUnits;


        for (int i = 0; i < 4; i++)
        {
            if (units[i] == unit)
            {
                return i;
            }
        }

        return 4; //whats the way to do this ah
    }

    public Unit GetUnit(int position, bool friendly)
    {
        Unit[] units;
        if (friendly)
            units = playerUnits;
        else
            units = enemyUnits;
        return units[position];
    }


}
