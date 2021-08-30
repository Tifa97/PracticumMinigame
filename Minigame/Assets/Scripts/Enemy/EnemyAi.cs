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
    //player health
    public float damage = 1f;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        //player health
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
}
