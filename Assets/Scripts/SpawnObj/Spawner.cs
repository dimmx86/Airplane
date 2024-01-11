using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CleanerSpawnObj cleaner;
    [SerializeField] private List<SpawnerData> spawnerData;
    [SerializeField] private Vector2 randomSpawnPosition;
    [SerializeField][Min(0.01f)] private float interval;

    private List<SpawnPool> spawnPool = new List<SpawnPool>();

    private WaitForSeconds waitInterval;

    private void Awake()
    {
        waitInterval = new WaitForSeconds(interval);
        InitPools();
        cleaner.OnCleanObj.AddListener(OnReturnInPool);
    }

    private IEnumerator Spawn()
    {
        yield return waitInterval;
    }

    private void InitPools()
    {
        spawnPool.Clear();
        for (int i = 0; i < spawnerData.Count; i++)
        {
            spawnPool.Add(CreatPool(spawnerData[i].spawnList));
        }
    }

    private SpawnPool CreatPool(SpawnList list)
    {
        List<SpawnObj> pool = new List<SpawnObj>();
        foreach (SpawnElement itam in list.SpawnElements)
        {
            for (int i = 0; i < itam.count; i++)
            {
                SpawnObj obj = Instantiate(itam.spawnObj);
                obj.gameObject.SetActive(false);
                pool.Add(obj);
            }
        }


        return new SpawnPool(pool);
    }

    private void OnReturnInPool(SpawnObj obj)
    {
        for(int i = 0;i < spawnPool.Count;i++)
        {
            if (spawnerData[i].spawnObjType == obj.GetTypeObj())
            {
                spawnPool[i].ReturnObject(obj);
                return;
            }
        }
        Destroy(obj.gameObject);
    }

    private void OnDestroy()
    {
        cleaner.OnCleanObj.RemoveListener(OnReturnInPool);
    }
}

[System.Serializable]
public struct SpawnerData
{
    public SpawnList spawnList;
    public int spawnCount;
    public bool isRandomRatation;
    public bool isSpawning;
    public SpawnObjType spawnObjType;
}
