using UnityEngine;
using System.Collections;

public class AmebasRuleStrategy : IRuleStrategy
{
    public string strategyName { get; private set; }

    public AmebasRuleStrategy()
    {
        strategyName = "Amebas";
    }

    //1358/357 (caótico) un reino equilibrado de amebas
    public bool CheckState(bool alive, int neighbours)
    {
        if(alive)
        {
            return (neighbours == 1 || neighbours == 3 || neighbours == 5 || neighbours == 8);
        }
        else
        {
            return (neighbours == 3 || neighbours == 5 || neighbours == 7);
        }
    }

    public string getName()
    {
        return strategyName;
    }
}
