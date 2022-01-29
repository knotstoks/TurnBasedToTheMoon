using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST, TRANSITION }
    BattleState battleState;

    [SerializeField] Party playerParty;
    Unit[] playerUnits;
    [SerializeField] Party enemyParty;
    Unit[] enemyUnits;
    Unit currentUnit = null;

    [SerializeField] private Transform[] characterLocations = new Transform[8];
    int[] actionSpeedArray = { 0, 0, 0, 0, 0, 0, 0, 0 };
    int[] actionValueArray = { 0, 0, 0, 0, 0, 0, 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        battleState = BattleState.START;
        LoadAllUnits();
        battleState = BattleState.TRANSITION;
    }

    // Update is called once per frame
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
            //pass to CombatController
        }

        if (battleState == BattleState.ENEMYTURN)
        {
            //Pass to EnemyController
        }


    }

    //called once on initialising combat scene
    void LoadAllUnits()
    {
        playerUnits = playerParty.getActiveUnitList();
        enemyUnits = enemyParty.getActiveUnitList();

        //players
        for (int i = 0; i < 4; i++)
        {
            if (playerUnits[i] != null)
            {
                Instantiate(playerUnits[i], characterLocations[i].position, Quaternion.identity);
                actionSpeedArray[i] = playerUnits[i].getSpeed();
            }
        }

        //enemies
        for (int i = 0; i < 4; i++)
        {
            if (enemyUnits[i] != null) {
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

                return enemyUnits[i-4];

            }
        }
        return null;
    }

    public void UpdateBattleState(BattleState newState)
    {
        battleState = newState;
    }

}
