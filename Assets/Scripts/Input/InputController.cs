using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    private Vector2 direction = Vector2.zero;
    private bool isInput = false;

    public bool IsInput { get { return isInput; } }
    public Vector2 Direction { get { return direction; } }

    public UnityEvent OnStart;
    public UnityEvent OnEnd;
    public UnityEvent<Vector2> OnChenget;


    private void OnEnable()
    {
        joystick.OnStartInput.AddListener(OnStartInput);
        joystick.OnInput.AddListener(OnInput);
        joystick.OnEndInput.AddListener(OnEndInput);
    }

    private void OnStartInput()
    {
        isInput = true;
        OnStart?.Invoke();
    }

    private void OnInput() 
    {
        direction = joystick.Direction;
        OnChenget?.Invoke(direction);
    }

    private void OnEndInput()
    {
        isInput = false;
        direction = Vector2.zero;
        OnEnd?.Invoke();
    }



    private void OnDisable()
    {
        joystick.OnStartInput.RemoveListener(OnStartInput);
        joystick.OnInput.RemoveListener(OnInput);
        joystick.OnEndInput.RemoveListener(OnEndInput);
    }
}
