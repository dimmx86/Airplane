using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputController input;
    [SerializeField] private PlayerControl control;
    [SerializeField] private Rigidbody rb;

    private void Awake()
    {
        control.StrartMove(rb);
        input.OnStart.AddListener(control.OnStartInput);
        input.OnChenget.AddListener(control.OnChengetInput);
        input.OnEnd.AddListener(control.OnStopInput);
    }

    private void OnDestroy()
    {
        input.OnStart.RemoveListener(control.OnStartInput);
        input.OnChenget.RemoveListener(control.OnChengetInput);
        input.OnEnd.RemoveListener(control.OnStopInput);
    }
}
