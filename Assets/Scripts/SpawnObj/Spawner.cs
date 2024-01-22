//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CleanerSpawnObj cleaner;
    [SerializeField] private List<SpawnerData> spawnerData;
    [SerializeField] private Vector2 randomSpawnPosition;
    [SerializeField][Min(0.01f)] private float interval;


    private float nextSpawnPosition;

    private void Awake()
    {
        nextSpawnPosition = transform.position.x + interval;
        InitPools();
        cleaner.OnCleanObj.AddListener(OnReturnInPool);
    }

    private void FixedUpdate()
    {
        if (transform.position.x > nextSpawnPosition)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        

            for (int i = 0; i < spawnerData.Count; i++)
            {
                if (!spawnerData[i].isSpawning) continue;

                for (int j = 0; j < spawnerData[i].spawnCount; j++)
                {
                    if (!spawnerData[i].spawnPool.IsObjInPool)
                    {
                        spawnerData[i].spawnPool.AddInPool(
                            CreatPool(spawnerData[i].spawnList));

                    }

                    SpawnObject(spawnerData[i].isRandomRatation,
                       spawnerData[i].spawnPool);
                }
            }
        
        nextSpawnPosition = transform.position.x + interval;
    }


    private void SpawnObject(bool isRandomRatation, SpawnPool pool)
    {
        if (pool.TryGetRandomObject(out SpawnObj obj))
        {
            if (NewSpawnPosition(obj.RadiusDeadZone, out Vector3 spawnPos))
            {
                obj.transform.position = spawnPos;
                if (isRandomRatation)
                {
                    obj.transform.rotation = Quaternion.Euler(
                        0f,
                        Random.Range(0f,360f),
                        0f);
                }
                obj.gameObject.SetActive(true);
            }
            else
            {
                pool.ReturnObject(obj);
                return;
            } 

        }
        else
        {
            //AddInPools();
            print("not obj in pool");
        }
    }

    private bool NewSpawnPosition(float radiusDeadZone, out Vector3 spawnPos)
    {
        
        spawnPos = Vector3.zero;
       
        for (int i = 0; i < 10 ; i++)
        {
            spawnPos.y = Random.Range(
                -randomSpawnPosition.y,
                randomSpawnPosition.y);
            spawnPos.x = Random.Range(
                -randomSpawnPosition.x,
                randomSpawnPosition.x);
            spawnPos = transform.position + spawnPos;
            RaycastHit[] hits = Physics.SphereCastAll(spawnPos, radiusDeadZone, Vector3.right);

            if (hits.Length > 0)
            {
                print("Bad position");
                continue;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    private void InitPools()
    {
        for (int i = 0; i < spawnerData.Count; i++)
        {
            spawnerData[i].spawnPool.AddInPool(CreatPool(spawnerData[i].spawnList));
        }
    }

    private List<SpawnObj> CreatPool(SpawnList list)
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


        return pool;
    }

    private void OnReturnInPool(SpawnObj obj)
    {
        for(int i = 0;i < spawnerData.Count;i++)
        {
            if (spawnerData[i].spawnObjType == obj.GetTypeObj())
            {
                spawnerData[i].spawnPool.ReturnObject(obj);
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
public class SpawnerData
{
    public SpawnList spawnList;
    public int spawnCount;
    public bool isRandomRatation;
    public bool isSpawning;
    public SpawnObjType spawnObjType;
    [HideInInspector] public SpawnPool spawnPool = new SpawnPool();
}
