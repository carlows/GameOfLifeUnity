using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LongLifeRuleStrategy : IRuleStrategy
{
    public string strategyName { get; private set; }

    public LongLifeRuleStrategy()
    {
        strategyName = "Long Life";
    }

    //51/346 (estable) "Larga vida" casi todo son osciladores
    public bool CheckState(bool alive, int neighbours)
    {
        if (alive)
        {
            return (neighbours == 1 || neighbours == 5);
        }
        else
        {
            return (neighbours == 3 || neighbours == 4 || neighbours == 6);
        }
    }

    public string getName()
    {
        return strategyName;
    }
}
