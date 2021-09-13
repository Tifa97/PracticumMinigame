using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public SpawningScriptableObject[] spawnSO;
    private GameObject target;
    public Transform spawnPoint;

    public static event Action<int> OnEnemiesSet;

    private int spawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find(Names.Player);
        if (spawnSO.Length > 0)
        {
            Spawn(spawnPoint.position, spawnSO[0].enemies);
        }
        if (spawnSO.Length > 1)
        {
            Spawn(spawnPoint.position, spawnSO[1].enemies);
        }
        if (spawnSO.Length > 2)
        {
            Spawn(spawnPoint.position, spawnSO[2].enemies);
        }
        if (spawnSO.Length > 3)
        {
            Spawn(spawnPoint.position, spawnSO[3].enemies);
        }
        if (spawnSO.Length > 4)
        {
            Spawn(spawnPoint.position, spawnSO[4].enemies);
        }

        CalculateNoOfEnemies();
    }

    private void CalculateNoOfEnemies()
    {
        int noOfEnemies = 0;

        foreach (var e in spawnSO)
        {
            noOfEnemies += e.enemies.Length;
        }

        OnEnemiesSet?.Invoke(noOfEnemies);
    }

    private void Spawn(Vector3 spawnPosition, EnemyTypes[] spawnEnemies)
    {
        for (int i = 0; i < spawnEnemies.Length; i++)
        {
            var enemy = FetchEnemy().GetComponent<EnemyAi>();
            enemy.transform.position = new Vector3(spawnPosition.x * RandomNumberGenerator.RandomNumber(), spawnPosition.y, spawnPosition.z * RandomNumberGenerator.RandomNumber());
        }
    }

    public static GameObject FetchEnemy()
    {
        return AssetProvider.GetAsset(GameAsset.Enemy);
    }
}
