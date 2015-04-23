using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Vida34RuleStrategy : IRuleStrategy
{
    public string strategyName { get; private set; }

    public Vida34RuleStrategy()
    {
        strategyName = "Vida34";
    }

    //34/34 (crece) "Vida 34"
    public bool CheckState(bool alive, int neighbours)
    {
        return (neighbours == 3 || neighbours == 4);
    }

    public string getName()
    {
        return strategyName;
    }
}