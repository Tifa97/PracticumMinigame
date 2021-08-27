using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameAsset bullet = GameAsset.Bullet;
    public GameObject weapon;
    public float bulletVelocity = 10f;
    public float fireRate = 0.2f;
    public Transform bulletPosition;

    void Start()
    {
        
    }

    public void Fire()
    {
        var shot = AssetProvider.GetAsset(bullet);
        shot.GetComponent<BulletController>().PrepareBullet(bulletPosition, bulletVelocity, Names.Enemy, 1f);
        shot.transform.position = bulletPosition.position;
        shot.transform.rotation = bulletPosition.rotation;
    }

    void Update()
    {
        
    }
}
