using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPool
{    
    private List<SpawnObj> poolObjects = new List<SpawnObj>();


    public bool IsObjInPool => poolObjects.Count > 0;

    public void AddInPool(List<SpawnObj> Objects)
    {


        foreach (SpawnObj obj in Objects)
        {
            if (obj != null)
            {
                poolObjects.Add(obj);
            }
        }
    }

    public void ReturnObject(SpawnObj obj)
    {
        obj.gameObject.SetActive(false);
        poolObjects.Add(obj);
    }

    public bool TryGetRandomObject(out SpawnObj obj)
    {
        obj = null;
        if (poolObjects.Count > 0)
        {
            int nObj = Random.Range(0, poolObjects.Count);
            obj = poolObjects[nObj];
            poolObjects.RemoveAt(nObj);
            return true;
        }
        return false;
    }


    
}
