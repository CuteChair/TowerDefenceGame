using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "TowerDefence/EnemyData")]
public class ScriptableEnemy : ScriptableObject
{
    public string enemyName;
    public float health;
    public float maxHealth;
    public float speed;
    public EnemyType enemyType;
}
