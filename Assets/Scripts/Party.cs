using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    [SerializeField] Unit unit_1;
    [SerializeField] Unit unit_2;
    [SerializeField] Unit unit_3;
    [SerializeField] Unit unit_4;

    public Unit[] getActiveUnitList()
    {
        Unit[] unitList = {unit_1, unit_2, unit_3, unit_4};
        return unitList;
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
