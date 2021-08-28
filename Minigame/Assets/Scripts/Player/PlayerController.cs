using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveDirection;
    private float speed = 5f;
    public Weapon weapon;

    void Start()
    {
        InputManager.OnMoved += RegisterMovement;
        InputManager.OnShootPressed += RegisterShooting;
        InputManager.OnStoppedShooting += RegisterShootingStopped;
    }

    private void RegisterShootingStopped()
    {
        //throw new NotImplementedException();
    }

    private void RegisterShooting()
    {
        weapon.Fire();
    }

    private void RegisterMovement(Vector3 direction)
    {
        moveDirection = direction;
    }

    private void FixedUpdate()
    {
        transform.position += moveDirection * Time.fixedDeltaTime * speed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        InputManager.OnMoved -= RegisterMovement;
        InputManager.OnShootPressed -= RegisterShooting;
        InputManager.OnStoppedShooting -= RegisterShootingStopped;
    }
}
