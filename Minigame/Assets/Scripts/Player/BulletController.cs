using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 originPosition;
    private float speed = 10f;
    private string shootingTarget;
    private float bulletDamage;

    private PoolableObject bulletObject;
    // Start is called before the first frame update
    void Start()
    {
        bulletObject = GetComponent<PoolableObject>();
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
        if (Vector3.Distance(transform.position, originPosition) > 10)
        {
            if (bulletObject != null)
            {
                bulletObject.ReturnToPool();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void PrepareBullet(Transform origin, float bulletSpeed, string target, float damage)
    {
        transform.position = origin.position;
        transform.rotation = origin.rotation;
        originPosition = transform.position;
        speed = bulletSpeed;
        shootingTarget = target;
        bulletDamage = damage;
    }
}
