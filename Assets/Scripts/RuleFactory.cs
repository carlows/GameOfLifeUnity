using UnityEngine;
using System.Collections;

public class RuleFactory {

	public static IRuleStrategy GetInstance(Modo modo)
    {
        if (modo == Modo.Conways)
            return new ConwaysRuleStrategy();
        else if (modo == Modo.Caos)
            return new CaosRuleStrategy();
        else if (modo == Modo.Replicas)
            return new ReplicasRuleStrategy();
        else if (modo == Modo.Amebas)
            return new AmebasRuleStrategy();
        else if (modo == Modo.HighLife)
            return new HighLifeRuleStrategy();
        else if (modo == Modo.DiffusionRule)
            return new DiffusionRuleStrategy();
        else if (modo == Modo.Muerte)
            return new MuerteRuleStrategy();
        else if (modo == Modo.Vida34)
            return new Vida34RuleStrategy();
        else if (modo == Modo.LongLife)
            return new LongLifeRuleStrategy();
        else
            return null;
    }
}
