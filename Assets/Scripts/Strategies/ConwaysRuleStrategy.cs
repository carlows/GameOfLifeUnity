using UnityEngine;
using System.Collections;

public class ConwaysRuleStrategy : IRuleStrategy
{
    public string strategyName { get; private set; }

    public ConwaysRuleStrategy()
    {
        strategyName = "Conway's Game Of Life";
    }

    public bool CheckState(bool alive, int neighbours)
    {
        if (alive)
            return !(neighbours < 2 || neighbours > 3);
        else
            return neighbours == 3;
    }

    public string getName()
    {
        return strategyName;
    }
}
