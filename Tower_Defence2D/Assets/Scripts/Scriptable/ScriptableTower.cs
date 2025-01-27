using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "TowerDefence/TowerData")]    

public class ScriptableTower : ScriptableObject, ITowerData
{
    public string towerName;

    public float towerDamage;

    public float towerRange;

    public float towerCD;

    public EnumTargetable targetableEnnemies;

    public float Damage => towerDamage;
    public float Range => towerRange;
    public float Cooldown => towerCD;

    public string Name => towerName;
    public EnumTargetable Targetable => targetableEnnemies;
}
