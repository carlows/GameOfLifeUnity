using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MuerteRuleStrategy : IRuleStrategy
{
    public string strategyName { get; private set; }

    public MuerteRuleStrategy()
    {
        strategyName = "Muerte";
    }

    //245/368 (estable) muerte, locomotoras y naves
    public bool CheckState(bool alive, int neighbours)
    {
        if (alive)
        {
            return (neighbours == 2 || neighbours == 4 || neighbours == 5);
        }
        else
        {
            return (neighbours == 3 || neighbours == 6 || neighbours == 8);
        }
    }

    public string getName()
    {
        return strategyName;
    }
}


