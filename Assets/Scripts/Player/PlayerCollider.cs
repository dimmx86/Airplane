using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //print("Player triger");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("Player collider");

    }
}
