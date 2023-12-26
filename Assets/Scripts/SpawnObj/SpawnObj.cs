using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    [SerializeField][Min(0.1f)] private float radiusDeadZone;

    public float RadiusDeadZone => radiusDeadZone;
}
