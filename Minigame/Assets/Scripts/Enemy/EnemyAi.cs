using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetPosition;
    public GameAsset rangedAsset = GameAsset.Bullet;
    public PlayerController player;
    public float damage = 1f;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        targetPosition = FindObjectOfType<PlayerController>().gameObject.transform;
    }

    void Update()
    {
        if (targetPosition == null)
        {
            targetPosition = FindObjectOfType<PlayerController>().gameObject.transform;
        }
        agent.SetDestination(targetPosition.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == Names.Player)
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
