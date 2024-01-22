using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : SpawnObj
{
    public override SpawnObjType GetTypeObj()
    {
        return SpawnObjType.Coin;
    }
}
