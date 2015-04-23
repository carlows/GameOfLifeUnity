using UnityEngine;
using System.Collections;

public class ReplicasRuleStrategy : IRuleStrategy
{
    // 1357/1357 (crece) todo son replicantes
    public string strategyName { get; private set; }

    public ReplicasRuleStrategy()
    {
        strategyName = "Replicas";
    }

    public bool CheckState(bool alive, int neighbours)
    {
        return neighbours % 2 == 1;
    }

    public string getName()
    {
        return strategyName;
    }
}
