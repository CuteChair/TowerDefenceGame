using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITowerData 
{
    float Damage { get; }
    float Range { get; }
    float Cooldown { get; }
    string Name { get; }

    EnumTargetable Targetable { get; }
}
