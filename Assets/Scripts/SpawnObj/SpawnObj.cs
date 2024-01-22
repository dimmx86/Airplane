using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    [SerializeField][Min(0.1f)] private float radiusDeadZone;


    public float RadiusDeadZone => radiusDeadZone;

    public virtual SpawnObjType GetTypeObj()
    {
        return SpawnObjType.Island;
    }
}

public enum SpawnObjType
{
    Island,
    Ñanister,
    Coin
}
