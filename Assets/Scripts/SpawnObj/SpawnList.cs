using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnListObj", menuName = "ScriptableObjects/SpawnList", order = 1)]
public class SpawnList : ScriptableObject
{
    [SerializeField] private List<SpawnElement> spawnElements;

    public List<SpawnElement> SpawnElements { get { return spawnElements; } }
}

[System.Serializable]
public struct SpawnElement
{
    public SpawnObj spawnObj;
    public int count;
}
