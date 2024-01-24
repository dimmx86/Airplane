using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private float scale = 1f;

    private Transform target;
    private Material material;
    private Vector2 offset;

    private void Awake()
    {
        target = transform.root.root;
        material = GetComponent<SpriteRenderer>().material;
    }

    private void FixedUpdate()
    {
        offset = new Vector2(target.position.x/1000*scale, target.position.y/1000*scale);
        material.mainTextureOffset = offset;
    }
}
