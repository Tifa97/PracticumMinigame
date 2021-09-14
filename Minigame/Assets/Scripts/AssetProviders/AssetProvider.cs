using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetProvider : AssetBaseProvider
{
    //public GameObject player;
    public GameObject bullet;
    public GameObject enemy;

    public int bulletPoolSize;
    public int defaultPoolSize = 10;
    private static AssetProvider _instance;
    public static AssetProvider Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<AssetProvider>("AssetProvider");
            }

            return _instance;
        }
    }

    protected override AssetBaseProvider GetInstance()
    {
        return Instance;
    }

    public static GameObject GetAsset(GameAsset asset)
    {
        return Instance.GetObjectFromPool(GameObjectForType(asset));
    }

    public static void Prewarm()
    {
        if (_instance == null)
        {
            _instance = Resources.Load<AssetProvider>("AssetProvider");

            _instance.poolObject = new GameObject();
            _instance.poolObject.name = "Pool";
            GameObject.DontDestroyOnLoad(_instance.poolObject);

            Instance.InstatiatePool(_instance.bullet, _instance.bulletPoolSize);

            Instance.InstatiatePool(_instance.enemy, _instance.defaultPoolSize);
        }
    }

    public PoolableObject RegisterObjectAsPoolable(GameObject gameObject, GameAsset type)
    {
        var poolable = gameObject.GetComponent<PoolableObject>();
        if (poolable == null)
        {
            poolable = gameObject.AddComponent<PoolableObject>();
        }

        poolable.SetPool(GameObjectForType(type), Instance);

        return poolable;
    }

    public static GameObject GameObjectForType(GameAsset type)
    {
        switch (type)
        {
            case GameAsset.Bullet:
                return Instance.bullet;
            case GameAsset.Enemy:
                return Instance.enemy;
            default:
                return null;
        }
    }

    public static void ReturnAllToPool()
    {
        foreach (var item in GameObject.FindObjectsOfType<PoolableObject>())
        {
            item.ReturnToPool();
        }
    }
}

public enum GameAsset
{
    Bullet,
    Enemy
}