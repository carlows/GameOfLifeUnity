using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DiffusionRuleStrategy : IRuleStrategy
{
    public string strategyName { get; private set; }

    public DiffusionRuleStrategy()
    {
        strategyName = "Diffusion";
    }

    //2/7 (caótico) "Diffusion Rule" (gliders, guns, puffer trains)
    public bool CheckState(bool alive, int neighbours)
    {
        if (alive)
        {
            return neighbours == 2;
        }
        else
        {
            return neighbours == 7;
        }
    }

    public string getName()
    {
        return strategyName;
    }
}

