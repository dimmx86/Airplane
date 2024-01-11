using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPool
{    
    private List<SpawnObj> poolObjects;

    public SpawnPool(List<SpawnObj> listObjects)
    {
        poolObjects = listObjects;
    }


    public void ReturnObject(SpawnObj obj)
    {
        obj.gameObject.SetActive(false);
        poolObjects.Add(obj);
    }

    public bool GetRandomObject(out SpawnObj obj)
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
