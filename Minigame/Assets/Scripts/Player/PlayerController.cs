using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveDirection;
    private float speed = 5f;
    public Weapon weapon;
    public new Camera camera;
    public float sensitivity = 150f;
    private float rotation = 0f;
    private CharacterController controller;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        var pos = GetComponent<PlayerController>().gameObject.transform.position;
        Debug.Log("My position: " + pos.x + ", " + pos.y );

        ToggleCursor(false);
        InputManager.OnMoved += RegisterMovement;
        InputManager.OnShootPressed += RegisterShooting;
        InputManager.OnStoppedShooting += RegisterShootingStopped;
    }

    private void ToggleCursor(bool isActive)
    {
        if (isActive)
        {
            Cursor.visible = isActive;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
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
        float moveX = Input.GetAxis(InputStrings.axisX);
        float moveZ = Input.GetAxis(InputStrings.axixY);

        Vector3 moveVector = controller.transform.forward * moveZ
            + controller.transform.right * moveX;

        moveVector *= speed * Time.deltaTime;

        //controller.Move(moveVector);

        /*jump
        if (Input.GetButtonDown(InputStrings.Jump) && IsOnGround())
        {
            velocity.y = 0.6f;
        }*/

        controller.Move(moveVector + velocity);
    }

    private void FixedUpdate()
    {
        transform.position += moveDirection * Time.fixedDeltaTime * speed;
        Rotate();
    }

    private void Rotate()
    {
        float x = Input.GetAxis(InputStrings.MouseX) * sensitivity * Time.deltaTime;
        float y = Input.GetAxis(InputStrings.MouseY) * sensitivity * Time.deltaTime;

        controller.transform.Rotate(Vector3.up * x);

        rotation -= y;

        rotation = Mathf.Clamp(rotation, -88f, 90f);

        camera.transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
        weapon.transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);
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

        ToggleCursor(true);
    }
}
