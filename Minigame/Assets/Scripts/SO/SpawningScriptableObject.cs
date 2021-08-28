using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawning", menuName = "ScriptableObjects/SpawningScriptableObject", order = 1)]
public class SpawningScriptableObject : ScriptableObject
{
    public int spawnTime;
    public EnemyTypes[] enemies;
}
