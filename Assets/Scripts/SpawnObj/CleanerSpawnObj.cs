using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CleanerSpawnObj : MonoBehaviour
{
    
    public UnityEvent<SpawnObj> OnCleanObj;

    private void OnTriggerEnter(Collider other)
    {        
        if (other.transform.parent.transform.parent.
            TryGetComponent<SpawnObj>(out SpawnObj spawnObj))
        {
            OnCleanObj?.Invoke(spawnObj);
        }
    }

}
