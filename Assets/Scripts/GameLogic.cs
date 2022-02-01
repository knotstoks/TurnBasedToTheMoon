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

    private void Start()
    {
        battleState = BattleState.START;
        LoadAllUnits();
        battleState = BattleState.TRANSITION;
    }

    private void Update()
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
        for (int i = 0; i < playerUnits.Length; i++)
        {
            Instantiate(playerUnits[i], characterLocations[i].position, Quaternion.identity);
            playerUnits[i].SetFriendly(true);
            actionSpeedArray[i] = playerUnits[i].GetSpeed();
        }

        // Enemies
        for (int i = 0; i < enemyUnits.Length; i++)
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

    // Reset speed and switch to transition
    public void FinishedTurn(Unit unit) 
    {
        int pos = GetPosition(unit);
        int arrayPos;
        if (unit.GetFriendly())
            arrayPos = 3 - pos;
        else
            arrayPos = pos + 4;
        actionValueArray[arrayPos] = 0;
        battleState = BattleState.TRANSITION; // TODO: There's no state for animations to play out
    }

    // Returns an int 0 - 3 depending on the position of the unit
    public int GetPosition(Unit unit)
    {
        if (unit.GetFriendly())
        {
            for (int i = 0; i < 4; i++)
            {
                if (playerUnits[i].Equals(unit))
                {
                    return i;
                }
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (enemyUnits[i].Equals(unit))
                {
                    return i;
                }
            }
        }

        throw new System.Exception("Unit is not found"); // TODO: Print log properly
    }

    public Unit GetUnit(int position, bool friendly)
    {
        return (friendly) ? playerUnits[position] : enemyUnits[position];
    }
}
