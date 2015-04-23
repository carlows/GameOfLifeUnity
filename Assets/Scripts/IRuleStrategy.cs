using UnityEngine;
using System.Collections;

public interface IRuleStrategy
{
    string getName();
    bool CheckState(bool alive, int neighbours);
}
