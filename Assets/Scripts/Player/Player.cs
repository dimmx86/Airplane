using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputController input;
    [SerializeField] private Mover mover;
    [SerializeField] private Rigidbody rb;
}
