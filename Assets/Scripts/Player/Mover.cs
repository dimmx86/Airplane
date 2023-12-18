using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //Вверх задрать тежелее чем вниз опустить,
    //при бросании штурвала 3 варианта в зави от текушего напровления

    [SerializeField][Min(0.1f)] private float minSpeed;
    [SerializeField][Min(0.1f)] private float maxSpeed;
    [SerializeField][Min(0.1f)] private float acceleration;
    [SerializeField][Range(0.1f,1.0f)] private float maxY;
    [SerializeField][Min(0.1f)] private float accelerationYUp;
    [SerializeField][Min(0.1f)] private float accelerationYDown;
    [SerializeField][Range(0.1f, 89.9f)] private float maxAngle;
    [SerializeField][Range(0.1f, 89.9f)] private float maxAnglePlane;

    private float normalSpeed;
    private bool isMove = false;
    private bool isFalls = false;
    private Rigidbody rigidbody;
    private Vector3 finalDirection;

    public void StartMover(Rigidbody rigidbody)
    {
        normalSpeed = (minSpeed + maxSpeed) / 2;
        this.rigidbody = rigidbody;
        isMove = true;
    }

    public void OnStartInput()
    {
        isFalls = false;

    }

    public void OnChengetInput(Vector2 direction) 
    {
        isFalls = false;

    }

    public void OnStopInput() 
    {
        isFalls = true;

        if (transform.eulerAngles.z >= maxAnglePlane)
        {

        }
        else if (transform.eulerAngles.z < maxAnglePlane &&
            transform.eulerAngles.z > 0)
        {

        }
        else
        {

        }
    }

    private IEnumerator Plane()
    {

    }

    private IEnumerator Falls()
    {

    }

    public void StopMover()
    {
        isMove = false;
    }
}
