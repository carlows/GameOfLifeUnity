using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HighLifeRuleStrategy : IRuleStrategy
{
     public string strategyName { get; private set; }

     public HighLifeRuleStrategy()
    {
        strategyName = "High Life";
    }

     //23/36 (caótico) "HighLife" (tiene replicante)
    public bool CheckState(bool alive, int neighbours)
    {
        if(alive)
        {
            return (neighbours == 2 || neighbours == 3);
        }
        else
        {
            return (neighbours == 3 || neighbours == 6);
        }
    }

    public string getName()
    {
        return strategyName;
    }
}
