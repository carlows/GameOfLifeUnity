using UnityEngine;
using System.Collections;

public class CaosRuleStrategy : IRuleStrategy
{
    public string strategyName { get; private set; }

    public CaosRuleStrategy()
    {
        strategyName = "Islands";
    }

    // 5678/35678 (caótico) diamantes, catástrofes
    public bool CheckState(bool alive, int neighbours)
    {
        if(alive)
        {
            return neighbours >= 5;
        }
        else
        {
            return neighbours == 3 || neighbours > 4;
        }
    }

    public string getName()
    {
        return strategyName;
    }
}
