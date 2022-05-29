using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : Singleton<MapGenerator>
{
    public bool IsMaxRoomCountReached { get => roomCount >= maxRoomCount; }
    public float SpawnCooldown { get => spawnCooldown; }
    [SerializeField] private float spawnCooldown;

    [SerializeField] private int maxRoomCount;
    private int roomCount = 1;

    [SerializeField] private NavMeshSurface navMeshSurface;

    public Room RandomRoom
    {
        get
        {
            int roomIndex = UnityEngine.Random.Range(0, roomPrefabs.Length) ;
            return roomPrefabs[roomIndex];
        }
    }
    [SerializeField] private Room[] roomPrefabs;
    [SerializeField] private Room startRoom;

    public Corridor corridor;

    public Action OnMaxRoomCountReached;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(SpawnCooldown);

        startRoom.StartCoroutine(startRoom.SetRandomDirection());
    }

    public void IncreaseRoomCount()
    {
        roomCount++;

        if(roomCount >= maxRoomCount)
        {
            Debug.Log("Action !");
            OnMaxRoomCountReached?.Invoke();
            navMeshSurface.BuildNavMesh();
        }
    }
}
