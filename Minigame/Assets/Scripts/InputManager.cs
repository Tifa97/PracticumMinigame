using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action OnShootPressed;
    public static event Action OnEscPressed;
    public static event Action<Vector3> OnMoved;
    public static event Action OnStoppedShooting;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            OnShootPressed?.Invoke();
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnStoppedShooting?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscPressed?.Invoke();
        }

        var inputX = Input.GetAxis(InputStrings.axisX);
        var inputY = Input.GetAxis(InputStrings.axixY);

        var movement = new Vector3(inputX, 0, inputY);
        OnMoved?.Invoke(movement.normalized);
    }

    public static void StartInputManager()
    {
        var inputManager = GameObject.Instantiate(new GameObject());

        inputManager.AddComponent<InputManager>();
        inputManager.name = Names.InputManager;

        GameObject.DontDestroyOnLoad(inputManager);
    }
}
