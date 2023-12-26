using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //Вверх задрать тежелее чем вниз опустить,
    //при бросании штурвала 3 варианта в зави от текушего напровления
    [SerializeField] private DirectionMove directionMove;

    [SerializeField][Min(0.1f)] private float minSpeed;
    [SerializeField][Min(0.1f)] private float maxSpeed;
    [SerializeField][Min(0.1f)] private float acceleration;
    [SerializeField][Range(0,1)] private float maxAngleFletSpeed = 0.05f;
   
    private float normalSpeed;
    private bool isMove = false;
    private bool isControl = false;
    private Rigidbody rigidbody;
    private Vector3 finalDirection = Vector3.right;
    private float currentSpeed;
    private float pawerFactor = 1;
    
    public void StartMover(Rigidbody rigidbody)
    {
        normalSpeed = (minSpeed + maxSpeed) / 2;
        this.rigidbody = rigidbody;
        isMove = true;
    }

    public void SetPawerFactor(float factor)
    {
        pawerFactor = factor;
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            finalDirection = directionMove.transform.position - transform.position;
            currentSpeed = normalSpeed * ForceFactor();
            rigidbody.velocity = Vector3.Lerp(
                rigidbody.velocity, finalDirection * currentSpeed
                , acceleration);
        }
    }

    private float ForceFactor()
    {
        float factor = 1;
        if (finalDirection.y > maxAngleFletSpeed ||
            finalDirection.y < -maxAngleFletSpeed)
        {
            factor = pawerFactor * (finalDirection.y * -1 + 1) / 2;
        }
        else
        {
            factor = pawerFactor;
        }

        return factor;
    }

    public void StopMover()
    {
        isMove = false;
    }
}
