using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, TRANSITION }
    private BattleState battleState;

    [SerializeField] private Party playerParty;
    private Unit[] playerUnits;
    [SerializeField] private Party enemyParty;
    Unit[] enemyUnits;
    Unit currentUnit = null;

    [SerializeField] private Transform[] characterLocations = new Transform[8]; // TODO: Should be hard coded, we adjust when we get the sprites in
    int[] actionSpeedArray = { 0, 0, 0, 0, 0, 0, 0, 0 };
    int[] actionValueArray = { 0, 0, 0, 0, 0, 0, 0, 0 };

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
            UpdateActionValue();
            currentUnit = CheckActionValue();
            if (currentUnit != null)
            {
                Debug.Log(currentUnit.gameObject.name + " is taking his turn!");
                if (currentUnit.getFriendly())
                    battleState = BattleState.PLAYERTURN;
                else
                    battleState = BattleState.ENEMYTURN;

            }
        }

        if (battleState == BattleState.PLAYERTURN)
        {
            // Pass to CombatController
        }

        if (battleState == BattleState.ENEMYTURN)
        {
            // Pass to EnemyController
        }


    }

    // Called once on initialising combat scene
    void LoadAllUnits()
    {
        playerUnits = playerParty.getActiveUnitList();
        enemyUnits = enemyParty.getActiveUnitList();

        // Player
        for (int i = 0; i < 4; i++) // Can make it better by just taking playerUnits.Count and remove null check
        {
            if (playerUnits[i] != null)
            {
                Instantiate(playerUnits[i], characterLocations[i].position, Quaternion.identity);
                actionSpeedArray[i] = playerUnits[i].getSpeed();
            }
        }

        // Enemies
        for (int i = 0; i < 4; i++) // Same for here
        {
            if (enemyUnits[i] != null) 
            {
                Instantiate(enemyUnits[i], characterLocations[i + 4].position, Quaternion.identity);
                actionSpeedArray[i + 4] = enemyUnits[i].getSpeed();
            }
        }
    }

    void UpdateActionValue()
    {
        for (int i = 0; i < 8; i++)
        {
            actionValueArray[i] += actionSpeedArray[i];
        }
    }

    Unit CheckActionValue()
    {
        for (int i = 0; i < 8; i++)
        {
            if (actionValueArray[i] >= 100)
            {
                if(i < 4)
                    return playerUnits[i];

                return enemyUnits[i - 4];

            }
        }
        return null;
    }

    public void UpdateBattleState(BattleState newState)
    {
        battleState = newState;
    }
}
